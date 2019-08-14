package md5e9f397e10686205bed12d8b5f7cd4bfc;


public class PickerInnerView
	extends android.widget.RelativeLayout
	implements
		mono.android.IGCUserPeer,
		android.widget.Checkable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isChecked:()Z:GetIsCheckedHandler:Android.Widget.ICheckableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_setChecked:(Z)V:GetSetChecked_ZHandler:Android.Widget.ICheckableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_toggle:()V:GetToggleHandler:Android.Widget.ICheckableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.PickerInnerView, SettingsView.Droid", PickerInnerView.class, __md_methods);
	}


	public PickerInnerView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PickerInnerView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.PickerInnerView, SettingsView.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public PickerInnerView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PickerInnerView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.PickerInnerView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public PickerInnerView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PickerInnerView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.PickerInnerView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PickerInnerView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == PickerInnerView.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.PickerInnerView, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean isChecked ()
	{
		return n_isChecked ();
	}

	private native boolean n_isChecked ();


	public void setChecked (boolean p0)
	{
		n_setChecked (p0);
	}

	private native void n_setChecked (boolean p0);


	public void toggle ()
	{
		n_toggle ();
	}

	private native void n_toggle ();

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
