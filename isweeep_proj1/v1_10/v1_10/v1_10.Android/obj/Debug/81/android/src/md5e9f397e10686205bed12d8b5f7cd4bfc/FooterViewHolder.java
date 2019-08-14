package md5e9f397e10686205bed12d8b5f7cd4bfc;


public class FooterViewHolder
	extends md5e9f397e10686205bed12d8b5f7cd4bfc.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.FooterViewHolder, SettingsView.Droid", FooterViewHolder.class, __md_methods);
	}


	public FooterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == FooterViewHolder.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.FooterViewHolder, SettingsView.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
