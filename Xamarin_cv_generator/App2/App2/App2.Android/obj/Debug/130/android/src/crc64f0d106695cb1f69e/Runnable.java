package crc64f0d106695cb1f69e;


public class Runnable
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.Runnable, Syncfusion.SfPdfViewer.XForms.Android", Runnable.class, __md_methods);
	}


	public Runnable ()
	{
		super ();
		if (getClass () == Runnable.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.Runnable, Syncfusion.SfPdfViewer.XForms.Android", "", this, new java.lang.Object[] {  });
		}
	}

	public Runnable (long p0, long p1, crc64f0d106695cb1f69e.ScrollViewEx p2)
	{
		super ();
		if (getClass () == Runnable.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.Runnable, Syncfusion.SfPdfViewer.XForms.Android", "System.Int64, mscorlib:System.Int64, mscorlib:Syncfusion.SfPdfViewer.XForms.Droid.ScrollViewEx, Syncfusion.SfPdfViewer.XForms.Android", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
