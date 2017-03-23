using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbAccessPlactice.DB;
using DbAccessPlactice.DB.社員DataSetTableAdapters;

namespace DbAccessPlactice.Model.社員Model
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

        public bool Update(List<社員更新用entity> 社員更新用entityList)
        {
            //社員更新用entiryとdataSet内のテーブルレコードの、社員番号を見て対応するレコードを更新する。
            foreach (var updateData in 社員更新用entityList)
            {

                if (updateData.社員番号 == null)
                {
                    //新規登録

                }
                else
                {
                    //更新
                    //更新対象record取得
                    var targetRecord = (from n in this.社員dataSet.社員
                                       where n.社員番号 == updateData.社員番号
                                       select n).First();

                    //氏名
                    targetRecord.氏名 = updateData.氏名;

                    //給与
                    if (updateData.給与 == null)
                    {
                        targetRecord.Set給与Null();
                    }
                    else
                    {
                        targetRecord.給与 = (int)updateData.給与;
                    }

                    //入社日
                    if (updateData.入社日 == null)
                    {
                        targetRecord.Set入社日Null();
                    }
                    else
                    {
                        targetRecord.入社日 = (DateTime)updateData.入社日;
                    }

                    //部門番号
                    targetRecord.部門番号 = updateData.部門番号;

                }
            }
            this.社員tableAdapter.Update(this.社員dataSet.社員);
            return true;
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

    class 社員更新用entity
    {
        public int? 社員番号 { get; set; }
        public string 氏名 { get; set; }
        public decimal? 給与 { get; set; }
        public DateTime? 入社日 { get; set; }
        public int 部門番号 { get; set; }
    }
}
