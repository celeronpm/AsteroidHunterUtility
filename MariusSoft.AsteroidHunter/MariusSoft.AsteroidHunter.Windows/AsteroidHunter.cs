using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;
using MariusSoft.WCSTools;

namespace MariusSoft.AsteroidHunter.Windows
{
    public partial class AsteroidHunter : Form
    {
        private Sample sample;
        private int selectedFrame = 0;
        GrayscaleOp gop = new ArcSinH();
        private bool calculating;

        public AsteroidHunter()
        {
            InitializeComponent();
        }

        private void AsteroidHunter_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading FITS...";

            Task.Factory.StartNew(() =>
            {
                DirectoryInfo dir = new DirectoryInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
                DirectoryInfo directory = dir.Parent.Parent.Parent.Parent;

                sample = new Sample(directory.FullName + "//example//01_12DEC02_N07060_0001.dets");
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
            })
                .ContinueWith(x =>
                {
                    comboDetections.Items.AddRange(sample.DetectionFile.DetInfos.Select(y =>y.DetNumber).Distinct().Select(z=> (object)z).ToArray());

                    lblInputMax.Text = Math.Round(sample.Frames[selectedFrame].InputStatistics.Max, 2).ToString();
                    lblInputMin.Text = Math.Round(sample.Frames[selectedFrame].InputStatistics.Min, 2).ToString();
                    lblInputMean.Text = Math.Round(sample.Frames[selectedFrame].InputStatistics.Mean, 2).ToString();
                    lblInputMedian.Text = Math.Round(sample.Frames[selectedFrame].InputStatistics.Median, 2).ToString();
                    lblInputStdDeviation.Text = Math.Round(sample.Frames[selectedFrame].InputStatistics.StandardDeviation, 2).ToString();

                    //Send the pixels8 to the ImagePanel control
                    imagePanel.SetParameters(sample.Frames[selectedFrame].InputData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, true, sample.DetectionFile, sample.Frames[selectedFrame], detections: chkDetections.Checked ? 1 : 0);
                    imagePanelModified.SetParameters(sample.Frames[selectedFrame].InputData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, true, sample.DetectionFile, sample.Frames[selectedFrame], chkDetections.Checked ? 1 : 0);

                    btnAutoCalc_Click(null, null);

                },
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadModifiedInfo(BitmapStatistics stats)
        {
            lblModifiedMax.Text = Math.Round(stats.Max, 2).ToString();
            lblModifiedMin.Text = Math.Round(stats.Min, 2).ToString();
            lblModifiedMean.Text = Math.Round(stats.Mean, 2).ToString();
            lblModifiedMedian.Text = Math.Round(stats.Median, 2).ToString();
            lblModifiedStdDev.Text = Math.Round(stats.StandardDeviation, 2).ToString();
        }

        private void numBlack_ValueChanged(object sender, EventArgs e)
        {
            Recalc();
        }

        private void rbLinear_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            if (rbLinear.Checked) gop = new LinearOp();
            else if (rbLog.Checked) gop = new LogOp();
            else if (rbArc.Checked)
            {
                gop = new ArcSinH();
                numScaled.Value = 10;
            }
            else if (rbExponential.Checked) gop = new ExponentOp();
            else if (rbGamma.Checked) gop = new GammaOp();

            Recalc();
        }

        private void Recalc()
        {
            if (sample.Frames[selectedFrame] == null || calculating)
            {
                return;
            }
            calculating = true;

            lblStatus.Text = "Stretching";
            numBlack.Enabled = false;
            numWhite.Enabled = false;
            numScaled.Enabled = false;
            rbLinear.Enabled = false;
            rbLog.Enabled = false;
            rbArc.Enabled = false;
            btnAutoCalc.Enabled = false;
            zzzzRangeBar1.Enabled = false;
            chkDetections.Enabled = false;
            btnZoomIn.Enabled = false;
            btnZoomOut.Enabled = false;
            btnResetZoom.Enabled = false;
            btnFrame1.Enabled = false;
            btnFrame2.Enabled = false;
            btnFrame3.Enabled = false;
            btnFrame4.Enabled = false;
            comboDetections.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                sample.Frames[selectedFrame].Scale((int)numBlack.Value, (int)numWhite.Value, (int)numScaled.Value, gop);
                imagePanelModified.SetParameters(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, false, sample.DetectionFile, sample.Frames[selectedFrame], sample.Frames[selectedFrame].ModifiedData.Max(), chkDetections.Checked ? 1 : 0);
                imagePanelModified.SetScroll(imagePanel.ScrollValues);

                sample.Frames[selectedFrame].ModifiedStatistics.Recalculate();
                double min = zzzzRangeBar1.RangeMinimum * .01;
                double max = 1 + ((100.00 / zzzzRangeBar1.RangeMaximum) - 1);
                imagePanelModified.SetLevels(min, max, sample.Frames[selectedFrame].ModifiedStatistics.Max);
                graphControl1.SetImage(sample.Frames[selectedFrame].ModifiedData, min, max);

            })
           .ContinueWith(x =>
           {
               LoadModifiedInfo(sample.Frames[selectedFrame].ModifiedStatistics);
               numBlack.Enabled = true;
               numWhite.Enabled = true;
               numScaled.Enabled = true;
               rbLinear.Enabled = true;
               rbLog.Enabled = true;
               rbArc.Enabled = true;
               btnAutoCalc.Enabled = true;
               zzzzRangeBar1.Enabled = true;
               chkDetections.Enabled = true;
               btnZoomIn.Enabled = true;
               btnZoomOut.Enabled = true;
               btnResetZoom.Enabled = true;
               btnFrame1.Enabled = true;
               btnFrame2.Enabled = true;
               btnFrame3.Enabled = true;
               btnFrame4.Enabled = true;
               comboDetections.Enabled = true;

               lblStatus.Text = "Collecting Garbage";
               GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
               GC.Collect();
               lblStatus.Text = "Idle";
               _3Dpanel1.SetData(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, imagePanel.ScrollValues, new Size(64, 64));
               calculating = false;

           },
          TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void levelMin_Scroll(object sender, EventArgs e)
        {
            lblStatus.Text = "Changing Range";

            Task.Factory.StartNew(() =>
            {
                double min = zzzzRangeBar1.RangeMinimum * .01;
                double max = 1 + ((100.00 / zzzzRangeBar1.RangeMaximum) - 1);

                graphControl1.SetRange(min, max);
                imagePanelModified.SetLevels(min, max, sample.Frames[selectedFrame].ModifiedStatistics.Max);
            })
         .ContinueWith(x =>
         {
             lblStatus.Text = "Idle";
         },
        TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void btnAutoCalc_Click(object sender, EventArgs e)
        {
            btnAutoCalc.Enabled = false;
            double black = 0;
            double white = (short.MaxValue * 2);

            Task.Factory.StartNew(() =>
            {
                //Scale back to default
                sample.Frames[selectedFrame].Scale(0, (short.MaxValue * 2) + 1, (short.MaxValue * 2) + 1, gop);

                //Resolution
                int xLength = 100;
                double[] temp = new double[xLength];
                double modifier = (temp.Length - 1) / sample.Frames[selectedFrame].ModifiedData.Max();

                int i;
                int iVal;
                for (i = 0; i < sample.Frames[selectedFrame].ModifiedData.Length; ++i)
                {
                    iVal = (int)(sample.Frames[selectedFrame].ModifiedData[i] * modifier);
                    ++temp[iVal];
                }

                double max = temp.Max();
                LogOp op = new LogOp();
                for (i = 0; i < temp.Length; i++)
                {
                    temp[i] = op.ComputeScale(0, max, temp[i]);
                }

                for (i = 1; i < temp.Length-3; i++)
                {
                    if (temp[i] < temp[i - 1] && temp[i + 1] > temp[i] && temp[i + 2] > temp[i+1])
                    {
                        black = (double)(((double)i / (double)xLength) * (double)(short.MaxValue * 2));
                        break;
                    }
                }

                for (i = temp.Length-1; i > 0; i--)
                {
                    if (temp[i] > 0 && temp[i - 1] > temp[i] && temp[i - 2] > temp[i-1])
                    {
                        white = (double)(((double)i / (double)xLength) * (double)(short.MaxValue * 2));
                        break;
                    }
                }
            }).ContinueWith(x =>
           {
               btnAutoCalc.Enabled = true;
               calculating = true;
               numBlack.Value = (decimal)black;
               calculating = false;
               numWhite.Value = (decimal)white;
           },
          TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            imagePanel.ZoomIn();
            imagePanelModified.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            imagePanel.ZoomOut();
            imagePanelModified.ZoomOut();
        }

        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            imagePanel.ZoomReset();
            imagePanelModified.ZoomReset();
        }

        private void chkDetections_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetections.Checked)
            {
                imagePanel.ShowDetections(1);
                imagePanelModified.ShowDetections(1);
            }
        }

        private void imagePanel_MouseMove(Point value)
        {
            if (sample == null)
            {
                return;
            }

            lblX.Text = value.X.ToString();
            lblY.Text = value.Y.ToString();

            double X;
            double Y;

            WCSUtil.ffwldp(value.X, value.Y, sample.Frames[selectedFrame].WcsReferenceValue.X, sample.Frames[selectedFrame].WcsReferenceValue.Y, sample.Frames[selectedFrame].WcsReferencePixel.X,
                sample.Frames[selectedFrame].WcsReferencePixel.Y, sample.Frames[selectedFrame].WcsScale.X, sample.Frames[selectedFrame].WcsScale.Y, sample.Frames[selectedFrame].WcsRotation, '-' + sample.Frames[selectedFrame].WcsType, out X,
                out Y);

            X -= 170;

            if (X < 0)
            {
                X += 10;
            }
            lblRA.Text = Math.Round(X,4).ToString();
            lblDEC.Text = Math.Round(Y, 4).ToString();
        }

        private void imagePanel_Scrolled(System.Drawing.Point value, System.Drawing.Point value2)
        {
            imagePanelModified.SetScroll(value);
            if ((MouseButtons & MouseButtons.Left) != MouseButtons.Left)
            {
                _3Dpanel1.SetData(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, value2, new Size(64, 64));
            }
        }

        private void imagePanelModified_Scrolled(System.Drawing.Point value, System.Drawing.Point value2)
        {
            imagePanel.SetScroll(value);
            if ((MouseButtons & MouseButtons.Left) != MouseButtons.Left)
            {
                _3Dpanel1.SetData(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, value2, new Size(64, 64));
            }
        }

        private void btnFrame1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (sender == btnFrame1)
            {
                i = 0;
            }
            else if (sender == btnFrame2)
            {
                i = 1;
            }
            else if (sender == btnFrame3)
            {
                i = 2;
            }
            else if (sender == btnFrame4)
            {
                i = 3;
            }
            selectedFrame = i;

            //Send the pixels8 to the ImagePanel control
            imagePanel.SetParameters(sample.Frames[selectedFrame].InputData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, true, sample.DetectionFile, sample.Frames[selectedFrame], detections: chkDetections.Checked ? 1 : 0);
            imagePanelModified.SetParameters(sample.Frames[selectedFrame].InputData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, true, sample.DetectionFile, sample.Frames[selectedFrame], chkDetections.Checked ? 1 : 0);


            //sample.Frames[selectedFrame].Scale((int)numBlack.Value, (int)numWhite.Value, (int)numScaled.Value, gop);
            imagePanelModified.SetParameters(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, sample.Frames[selectedFrame].InputSize.Height, false, sample.DetectionFile, sample.Frames[selectedFrame], sample.Frames[selectedFrame].ModifiedData.Max(), chkDetections.Checked ? 1 : 0);
            imagePanelModified.SetScroll(imagePanel.ScrollValues);

            //sample.Frames[selectedFrame].ModifiedStatistics.Recalculate();
            double min = zzzzRangeBar1.RangeMinimum * .01;
            double max = 1 + ((100.00 / zzzzRangeBar1.RangeMaximum) - 1);
            imagePanelModified.SetLevels(min, max, sample.Frames[selectedFrame].ModifiedStatistics.Max);
            graphControl1.SetImage(sample.Frames[selectedFrame].ModifiedData, min, max);

        }

        private void comboDetections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Detection det= sample.DetectionFile.DetInfos.First(x => x.Frame == selectedFrame+1 && x.DetNumber == (int)comboDetections.SelectedItem);

            double xcoord;
            double ycoord;
            GetXY(det, out xcoord, out ycoord);

            imagePanel.GoTo(xcoord, ycoord);
            imagePanelModified.GoTo(xcoord, ycoord);

            _3Dpanel1.SetData(sample.Frames[selectedFrame].ModifiedData, sample.Frames[selectedFrame].InputSize.Width, imagePanel.ScrollValues, new Size(64, 64));
           
        }

        private void GetXY(Detection detection, out double x, out double y)
        {
            WCSUtil.ffxypx(detection.RaHours * 15, detection.DecDeg, sample.Frames[selectedFrame].WcsReferenceValue.X, sample.Frames[selectedFrame].WcsReferenceValue.Y, sample.Frames[selectedFrame].WcsReferencePixel.X,
                sample.Frames[selectedFrame].WcsReferencePixel.Y, sample.Frames[selectedFrame].WcsScale.X, sample.Frames[selectedFrame].WcsScale.Y, sample.Frames[selectedFrame].WcsRotation, '-' + sample.Frames[selectedFrame].WcsType, out x,
                out y);

            y = sample.Frames[selectedFrame].InputSize.Height - y;
            x = sample.Frames[selectedFrame].InputSize.Width - x;
        }
         
    }
}
