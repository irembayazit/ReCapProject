using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrate
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        //default varsayılan geri donus degerini kullanır : ör --> int ise int deger dondurur
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
