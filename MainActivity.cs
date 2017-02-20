using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Gms.Vision.Barcodes;
using Android.Gms.Vision;
using Android.Graphics;
using Android.Runtime;
using System;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using static Android.Gms.Vision.Detector;
using Android.Util;
using Android.Content;

namespace XamarinQrCodeCamera
{
    [Activity(Label = "XamarinQrCodeCamera", MainLauncher = true, Icon = "@drawable/icon",Theme="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity,ISurfaceHolderCallback,IProcessor
    {
        SurfaceView cameraPreview;
        TextView txtResult;
        BarcodeDetector barcodeDetector;
        CameraSource cameraSource;
        const int RequestCameraPermissionID = 1001;


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
           switch(requestCode)
            {
                case RequestCameraPermissionID:
                    {
                        if(grantResults[0] == Permission.Granted)
                        {
                            if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
                            {
                                //Request permission
                                ActivityCompat.RequestPermissions(this, new string[]
                                {
                   Manifest.Permission.Camera
                                }, RequestCameraPermissionID);
                                return;
                            }
                            try
                            {
                                cameraSource.Start(cameraPreview.Holder);
                            }
                            catch (InvalidOperationException)
                            {

                            }
                        }
                    }
                    break;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            cameraPreview = FindViewById<SurfaceView>(Resource.Id.cameraPreview);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);

            barcodeDetector = new BarcodeDetector.Builder(this)
                .SetBarcodeFormats(BarcodeFormat.QrCode)
                .Build();
            cameraSource = new CameraSource
                .Builder(this, barcodeDetector)
                .SetRequestedPreviewSize(640, 480)
                .Build();

            cameraPreview.Holder.AddCallback(this);
            barcodeDetector.SetProcessor(this);
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
            
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
           if(ActivityCompat.CheckSelfPermission(ApplicationContext,Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                //Request permission
                ActivityCompat.RequestPermissions(this, new string[]
                {
                   Manifest.Permission.Camera
                }, RequestCameraPermissionID);
                return;
            }
           try
            {
                cameraSource.Start(cameraPreview.Holder);
            }
            catch (InvalidOperationException)
            {

            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            cameraSource.Stop();
        }

        public void ReceiveDetections(Detections detections)
        {
            SparseArray qrcodes = detections.DetectedItems;
            if(qrcodes.Size() != 0)
            {
                txtResult.Post(() => {
                    Vibrator vib = (Vibrator)GetSystemService(Context.VibratorService);
                    vib.Vibrate(1000);
                    txtResult.Text = ((Barcode)qrcodes.ValueAt(0)).RawValue;
                });
            }
        }

        public void Release()
        {
            
        }
    }
}

