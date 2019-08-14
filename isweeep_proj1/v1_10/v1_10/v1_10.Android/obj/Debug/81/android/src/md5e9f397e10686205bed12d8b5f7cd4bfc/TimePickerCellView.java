package md5e9f397e10686205bed12d8b5f7cd4bfc;


public class TimePickerCellView
	extends md5e9f397e10686205bed12d8b5f7cd4bfc.LabelCellView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.TimePickerCellView, SettingsView.Droid", TimePickerCellView.class, __md_methods);
	}


	public TimePickerCellView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == TimePickerCellView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.TimePickerCellView, SettingsView.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public TimePickerCellView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == TimePickerCellView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.TimePickerCellView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public TimePickerCellView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == TimePickerCellView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.TimePickerCellView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public TimePickerCellView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == TimePickerCellView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.TimePickerCellView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
