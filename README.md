# isweeep_proj_v1.2
 This project is designed to investigate the CVD index of a person, and is more parametized with weather condition.<br />
	This App is written in C# and xamarin forms, so both android and ios platform are supported.<br />
	This app includes the following functions:<br />
	1. **CVD calculator**<br />
	2. **Interval Timer**<br />
	3. **Weather forecast** and <br />
	4. **showing previous records**.<br />
## CVD calculator
The calculator runs everyday in the morning to calculate your CVD index, taking weather conditon into account.<br />
		Thus, the app may send you some reminder(溫提) so that you can take a look and mind your health.<br />
## Interval Timer
 You could consider it as a countdown timer, but once you have set the rest time and the work time, <br />
	the timer countdown the two times repeatedly, so when time is up, you could either return to work, <br />
	or take a rest. *Note that it is not recommended to quit the app when the timer is running.*<br />
## Weather forecast
 Since weather condition is now also taken into account, the app shows you the temperature and humidity
	of the next 5 days.
## Previous records
 Here, you can check the CVD index, weather conditions, concentrations of pollutants in the past.<br />
## References
[Here shows part of the calculations.](https://www.ncbi.nlm.nih.gov/pmc/articles/PMC2279177/)

## Notes
This is the code for calculating the cvd.
```c#
 private double calcvd(DB_pdata c, double tem, List<AirQuality> aq,bool ishol)
        {
            DateTime td = DateTime.Today;
            Func<int, int> f = x => (x < 0) ? -1 : 0;

            double age = (DateTime.Today.Year - c.dob.Year);
            if (td.Month < c.dob.Month || td.Day < c.dob.Day) age--;

            double height = c.heig;
            double weight = c.weig;
            bool gender = c.genD;
            double SP = c.Sbp;
            double DP = c.Dbp;
            double CL = c.Cho;
            double BH = c.hdll;
            bool is_smoker = c.smoK;
            bool is_diabetic = c.diaB;

            double temp = tem;
            double frs = 0;
            double pm_2_5 = getwmean((std(aq[0].HE_PM2_5) + std(aq[1].HE_PM2_5)) / 2,
                (std(aq[2].HE_PM2_5) + std(aq[3].HE_PM2_5)) / 2,
                (std(aq[4].HE_PM2_5) + std(aq[5].HE_PM2_5)) / 2);
            double pm_10 = getwmean((std(aq[0].HE_PM10) + std(aq[1].HE_PM10)) / 2,
                (std(aq[2].HE_PM10) + std(aq[3].HE_PM10)) / 2,
                (std(aq[4].HE_PM10) + std(aq[5].HE_PM10)) / 2);
            double so2 = getwmean((std(aq[0].HE_SO2) + std(aq[1].HE_SO2)) / 2,
                (std(aq[2].HE_SO2) + std(aq[3].HE_SO2)) / 2,
                (std(aq[4].HE_SO2) + std(aq[5].HE_SO2)) / 2);
            double no2 = getwmean((std(aq[0].HE_NO2) + std(aq[1].HE_NO2)) / 2,
                (std(aq[2].HE_NO2) + std(aq[3].HE_NO2)) / 2,
                (std(aq[4].HE_NO2) + std(aq[5].HE_NO2)) / 2);
            //age factor=====================================
            if (age >= 30 && age < 35) frs--;
            else if (age >= 40 && age < 45) frs++;
            else if (age >= 45 && age < 50) frs += 2;
            else if (age >= 50 && age < 55) frs += 3;
            else if (age >= 55 && age < 60) frs += 4;
            else if (age >= 60 && age < 65) frs += 5;
            else if (age >= 65 && age < 70) frs += 6;
            else if (age >= 70 && age < 75) frs += 7;
            //cholesterol level===============================
            if (CL < 160) frs -= 3;
            else if (CL >= 160 && CL < 200) frs += 0;
            else if (CL >= 200 && CL < 240) frs++;
            else if (CL >= 240 && CL < 280) frs += 2;
            else frs += 3;
            //blood HDL=======================================
            if (BH < 35) frs += 2;
            else if (BH >= 35 && BH < 45) frs++;
            else if (BH >= 45 && BH < 60) frs += 0;
            else frs -= 2;
            //blood pressure==================================
            if (SP >= 160 || DP >= 100) frs += 3;
            else if (SP >= 140 || DP >= 90) frs += 2;
            else if (SP >= 130 || DP >= 85) frs++;
            //else frs += 0;
            //is_diabetic=====================================
            if (is_diabetic) frs += 2;
            //is_smoker=======================================
            if (is_smoker) frs += 2;
            //convert to probability
            if (frs <= -3) frs = 0.01;
            else if (frs == -2) frs = 0.02;
            else if (frs == -1) frs = 0.02;
            else if (frs == 0) frs = 0.03;
            else if (frs == 1) frs = 0.04;
            else if (frs == 2) frs = 0.04;
            else if (frs == 3) frs = 0.06;
            else if (frs == 4) frs = 0.07;
            else if (frs == 5) frs = 0.09;
            else if (frs == 6) frs = 0.11;
            else if (frs == 7) frs = 0.14;
            else if (frs == 8) frs = 0.18;
            else if (frs == 9) frs = 0.22;
            else if (frs == 10) frs = 0.27;
            else if (frs == 11) frs = 0.33;
            else if (frs == 12) frs = 0.4;
            else if (frs == 13) frs = 0.47;
            else if (frs == 14) frs = 0.56;

            //temperature=====================================
            if (temp > 26) frs *= Math.Pow(1.17, (temp - 26));
            else if (temp < 26) frs *= Math.Pow(1.12, (-temp + 26));
            //air quality=====================================
            if (pm_2_5 > 96.2) frs *= Math.Pow(1.27, (pm_2_5 - 96.2) / 10);
            if (pm_10 > 115.6 && age >= 65) frs *= Math.Pow(1.012, (pm_10 - 115.6) / 10);
            if (so2 >= 53.21) frs *= Math.Pow(1.01, (so2 - 53.21)/10);
            if (no2 >= 53.08) frs *= Math.Pow(1.019, (no2 - 53.08)/10);

            //holiday factor
            if (ishol) frs *= 2.375;
            return frs;
        }
```
