package md5e9f397e10686205bed12d8b5f7cd4bfc;


public class MemoryLimitedLruCache
	extends android.util.LruCache
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_sizeOf:(Ljava/lang/Object;Ljava/lang/Object;)I:GetSizeOf_Ljava_lang_Object_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.MemoryLimitedLruCache, SettingsView.Droid", MemoryLimitedLruCache.class, __md_methods);
	}


	public MemoryLimitedLruCache (int p0)
	{
		super (p0);
		if (getClass () == MemoryLimitedLruCache.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.MemoryLimitedLruCache, SettingsView.Droid", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public int sizeOf (java.lang.Object p0, java.lang.Object p1)
	{
		return n_sizeOf (p0, p1);
	}

	private native int n_sizeOf (java.lang.Object p0, java.lang.Object p1);

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
