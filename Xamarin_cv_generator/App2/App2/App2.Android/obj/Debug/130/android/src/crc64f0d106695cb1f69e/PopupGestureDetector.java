package crc64f0d106695cb1f69e;


public class PopupGestureDetector
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSingleTapConfirmed:(Landroid/view/MotionEvent;)Z:GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler\n" +
			"n_onLongPress:(Landroid/view/MotionEvent;)V:GetOnLongPress_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.PopupGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", PopupGestureDetector.class, __md_methods);
	}


	public PopupGestureDetector ()
	{
		super ();
		if (getClass () == PopupGestureDetector.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.PopupGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "", this, new java.lang.Object[] {  });
		}
	}

	public PopupGestureDetector (crc64f0d106695cb1f69e.PopupAnnotationView p0, crc64f0d106695cb1f69e.TransparentCanvas p1)
	{
		super ();
		if (getClass () == PopupGestureDetector.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.PopupGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "Syncfusion.SfPdfViewer.XForms.Droid.PopupAnnotationView, Syncfusion.SfPdfViewer.XForms.Android:Syncfusion.SfPdfViewer.XForms.Droid.TransparentCanvas, Syncfusion.SfPdfViewer.XForms.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public boolean onSingleTapConfirmed (android.view.MotionEvent p0)
	{
		return n_onSingleTapConfirmed (p0);
	}

	private native boolean n_onSingleTapConfirmed (android.view.MotionEvent p0);


	public void onLongPress (android.view.MotionEvent p0)
	{
		n_onLongPress (p0);
	}

	private native void n_onLongPress (android.view.MotionEvent p0);

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
