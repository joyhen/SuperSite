using System.Collections.Generic;

namespace Model.Arg
{
    public class PArgUploadWebImg : IAjaxArg
    {
        /// <summary>
        /// 要上传的远程图片地址集合
        /// </summary>
        public List<upimg> imgs { get; set; }
    }

    public class upimg
    {
        public string k { get; set; }
    }
}