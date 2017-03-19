using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbAccessPlactice.DB;
using DbAccessPlactice.DB.社員DataSetTableAdapters;

namespace DbAccessPlactice.Model
{
    class 社員Model
    {
        private 社員DataSet 社員dataSet = new 社員DataSet();
        private 社員TableAdapter 社員tableAdapter = new 社員TableAdapter();

        public 社員Model()
        {
        }

        public List<社員取得用entity> get社員ListBy部門番号(int 部門番号)
        {
            var retList = new List<社員取得用entity>();
            this.社員tableAdapter.Fill(this.社員dataSet.社員, 部門番号);
            foreach (var record in this.社員dataSet.社員)
            {
                var obj = new 社員取得用entity()
                {
                    社員番号 = record.社員番号,
                    氏名 = record.氏名,
                    給与 = record.Is給与Null() ? null : (decimal?)record.給与,
                    入社日 = record.Is入社日Null() ? null : (DateTime?)record.入社日,
                    部門番号 = record.部門番号,
                };
                retList.Add(obj);
            }
            return retList;
        }

    }

    class 社員取得用entity
    {
        public int 社員番号 { get; set; }
        public string 氏名 { get; set; }
        public decimal? 給与 { get; set; }
        public DateTime? 入社日 { get; set; }
        public int 部門番号 { get; set; }
    }
}
