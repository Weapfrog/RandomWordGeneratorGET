using RandomWordGeneratorGET.Core;
using RandomWordGeneratorGET.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWordGeneratorGET.Business
{
    public class UnitOfWork
    {
        DapperHelper helper = new DapperHelper();
        public UnitOfWork()
        {

        }
        public List<Words> GetWords()
        {
            try
            {
                return helper.GetWord();
            }
            catch (Exception ex)
            {
                return new List<Words>();
            }
        }
        public List<Words> GetAllWords()
        {
            try
            {
                return helper.GetAllWords();
            }
            catch (Exception ex)
            {
                return new List<Words>();
            }
        }
    }
}
