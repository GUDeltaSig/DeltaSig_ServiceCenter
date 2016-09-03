using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaSigServiceCenter_DEV.Models
{
    public class BrothersInfo_BLL
    {
        private BrothersInfo_DAL broDataRetreiver;

        public List<Brother> requestAllBrothersHours()
        {
            List<Brother> broDataHolder = null;

            try
            {
                broDataRetreiver = new BrothersInfo_DAL();
                broDataHolder = broDataRetreiver.getBrothersHours();
            }
            catch (Exception e)
            {
                LogException(e);
            }

            return broDataHolder;
        }

        public bool requestBrotherAddition(Brother pendingBrother)
        {
            broDataRetreiver = new BrothersInfo_DAL();

            try
            {
                if (broDataRetreiver.checkForExistingBro(pendingBrother) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            } catch (Exception e)
            {
                LogException(e);
                //Error happened so the new brother could not be added
                return false;
            }
        }

        private void LogException(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}