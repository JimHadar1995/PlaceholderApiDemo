using FrameWork.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceholderApiDemo.Library.Models {
    public class Album : IBaseObject {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
