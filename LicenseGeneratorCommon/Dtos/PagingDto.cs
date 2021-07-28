using System.Collections.Generic;

namespace LicenseGenerator.Common.Dtos
{

    /// <summary>
    /// پیجینگ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingDto<T>
    {
        /// <summary>
        /// لیست آیتم ها
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// تعداد
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// شماره صفحه
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// تعداد کل آیتم ها
        /// </summary>
        public int Total { get; set; }

    }
}
