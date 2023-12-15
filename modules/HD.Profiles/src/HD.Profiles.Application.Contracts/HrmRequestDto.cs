using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.Profiles
{
    public class HrmRequestDto : PagedAndSortedResultRequestDto,ICloneable
    {
        public string View { get; set; } = "dashboard";

        public object Clone()
        {
            // Sử dụng MemberwiseClone để tạo bản sao nông của đối tượng
            HrmRequestDto clonedObject = (HrmRequestDto)this.MemberwiseClone();

            // Nếu có các thành phần tham chiếu, bạn cần thực hiện clone sâu cho chúng
            // Ví dụ: clonedObject.SomeReference = this.SomeReference.Clone();

            return clonedObject;
        }
    }
}
