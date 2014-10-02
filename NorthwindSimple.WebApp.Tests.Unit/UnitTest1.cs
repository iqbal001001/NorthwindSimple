using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Northwind.WebApp.Htmlhelper;


namespace NorthwindSimple.WebApp.Tests.Unit
{
    [TestClass]
    public class UnitTest1
    {
       // private string imageString = "0x151C2F00020000000D000E00140021";


        [TestMethod]
        public void TestMethod1()
        {
        }


        private class FakeHttpContext : HttpContextBase
        {
            private Dictionary<object, object> _items = new Dictionary<object, object>();
            public override IDictionary Items { get { return _items; } }
        }

        private class FakeViewDataContainer : IViewDataContainer
        {
            private ViewDataDictionary _viewData = new ViewDataDictionary();
            public ViewDataDictionary ViewData { get { return _viewData; } set { _viewData = value; } }
        }

        [TestMethod]
        //public void MyTable_should_render_HTML_table_with_id_from_http_context()
        //{

        //    //var httpContext = Substitute.For<HttpContext>();
        //    //httpContext.CalculateCost(100).Returns(12);

        //    //var viewDataContainer = Substitute.For<ViewDataContainer>();
        //    var myHelper = new HtmlHelper();
        //    var vc = new ViewContext();
        //    vc.HttpContext = new FakeHttpContext();
        //    vc.HttpContext.Items.Add("src", "foo");
        //    var hh = new HtmlHelper(vc, new FakeViewDataContainer());
        //     var image = new byte[];

        //    var result = myHelper.Image(image).ToString();

        //    Assert.AreEqual("<img src = \"foo\">", result);
        //}

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
