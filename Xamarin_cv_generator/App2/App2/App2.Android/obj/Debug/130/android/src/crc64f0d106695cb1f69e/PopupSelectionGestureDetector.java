package crc64f0d106695cb1f69e;


public class PopupSelectionGestureDetector
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDoubleTap:(Landroid/view/MotionEvent;)Z:GetOnDoubleTap_Landroid_view_MotionEvent_Handler\n" +
			"n_onSingleTapConfirmed:(Landroid/view/MotionEvent;)Z:GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.PopupSelectionGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", PopupSelectionGestureDetector.class, __md_methods);
	}


	public PopupSelectionGestureDetector ()
	{
		super ();
		if (getClass () == PopupSelectionGestureDetector.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.PopupSelectionGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "", this, new java.lang.Object[] {  });
		}
	}

	public PopupSelectionGestureDetector (crc64f0d106695cb1f69e.PopupSelectionBorderView p0)
	{
		super ();
		if (getClass () == PopupSelectionGestureDetector.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.PopupSelectionGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "Syncfusion.SfPdfViewer.XForms.Droid.PopupSelectionBorderView, Syncfusion.SfPdfViewer.XForms.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public boolean onDoubleTap (android.view.MotionEvent p0)
	{
		return n_onDoubleTap (p0);
	}

	private native boolean n_onDoubleTap (android.view.MotionEvent p0);


	public boolean onSingleTapConfirmed (android.view.MotionEvent p0)
	{
		return n_onSingleTapConfirmed (p0);
	}

	private native boolean n_onSingleTapConfirmed (android.view.MotionEvent p0);

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
