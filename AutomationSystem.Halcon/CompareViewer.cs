﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace AutomationSystem.Halcon
{
    public partial class CompareViewer : UserControl
    {
        private bool _ShowToolbar = false;
        [Category("自定义"), Description("是否展示工具栏"), Browsable(true)]
        public bool ShowToolbar
        {
            get { return _ShowToolbar; }
            set
            {
                _ShowToolbar = value;
                hObjectViewerSource.ShowToolbar = _ShowToolbar;
            }
        }

        public CompareViewer()
        {
            InitializeComponent();
        }

        public void SetSoureImage(HImage hImage)
        {
            hObjectViewerSource.SetImage(hImage);
        }

        public void SetCompareImage(HImage hImage)
        {
            hObjectViewerCompare.SetImage(hImage);
        }

        //public void SetImageHandle(HDrawingObject.HDrawingObjectCallbackClass hDrawingObjectCallbackClass)
        //{
        //    hObjectViewerSource.SetImageHandle(hDrawingObjectCallbackClass);
        //}

        public void SetImageHandle(Action action)
        {
            hObjectViewerSource.SetImageHandle(action);
        }

        public void SetROICount(int count)
        {
            hObjectViewerSource.SetROICount(count);
        }

        public void SetROIs(List<ROIBase> rois)
        {
            hObjectViewerSource.SetROIs(rois);
        }

        public List<ROIBase> GetROIs()
        {
            return hObjectViewerSource.GetROIs();
        }

        public void AttachDrawObj(ROIBase obj)
        {
            obj.CreateDrawingObject();
            hObjectViewerSource.AttachDrawObj(obj);
        }

        public HRegion GetRegions()
        {
            return hObjectViewerSource.GetRegions();
        }

        public HImage GetSoureImage()
        {
            return hObjectViewerSource.Source_Image;
        }

        public HImage GetCompareImage()
        {
            return hObjectViewerCompare.Source_Image;
        }

        ~CompareViewer()
        {
            ReleaseRam();
        }

        public void ReleaseRam()
        {
            hObjectViewerSource.ReleaseRam();
            hObjectViewerCompare.ReleaseRam();
            this.Dispose();
            GC.Collect();
        }
    }
}
