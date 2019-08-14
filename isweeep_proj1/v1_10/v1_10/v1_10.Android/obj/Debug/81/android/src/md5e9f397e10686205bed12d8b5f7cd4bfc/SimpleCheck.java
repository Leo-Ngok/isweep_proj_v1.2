package md5e9f397e10686205bed12d8b5f7cd4bfc;


public class SimpleCheck
	extends android.view.View
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isSelected:()Z:GetIsSelectedHandler\n" +
			"n_setSelected:(Z)V:GetSetSelected_ZHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.SimpleCheck, SettingsView.Droid", SimpleCheck.class, __md_methods);
	}


	public SimpleCheck (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SimpleCheck.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SimpleCheck, SettingsView.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SimpleCheck (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SimpleCheck.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SimpleCheck, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SimpleCheck (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SimpleCheck.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SimpleCheck, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SimpleCheck (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SimpleCheck.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SimpleCheck, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean isSelected ()
	{
		return n_isSelected ();
	}

	private native boolean n_isSelected ();


	public void setSelected (boolean p0)
	{
		n_setSelected (p0);
	}

	private native void n_setSelected (boolean p0);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

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
