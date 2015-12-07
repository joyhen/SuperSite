using System;

namespace Model.DTO
{
    public class TransferModel<T> where T : class
    {
        public bool success { get; set; }

        public string msg { get; set; }

        public T value { get; set; }
    }
}