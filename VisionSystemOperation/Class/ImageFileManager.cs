using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace VisionSystemOperation.Class
{
    public class FileDeleteManager
    {
        private DriveInfo m_hddInfo = new DriveInfo("D");
        double m_dUsedDiskPercentage = 0;

        public FileDeleteManager(string drive = "D")
        {
            m_hddInfo = new DriveInfo(drive);
        }

        private void GetOldImagePath(string dir, ref DirectoryInfo delFilePath)
        {
            try
            {
                DirectoryInfo rootPath = new DirectoryInfo(dir);
                DirectoryInfo[] dirs = rootPath.GetDirectories();

                if (dirs.Count() == 0)
                    return;

                double maxTime = 0;
                double curTime = DateTime.Now.ToFileTime();
                foreach (DirectoryInfo di in dirs)
                {
                    double fileTime = di.CreationTime.ToFileTime();

                    double difTime = curTime - fileTime;
                    if (maxTime < difTime)
                    {
                        maxTime = difTime;
                        delFilePath = new DirectoryInfo(di.FullName);
                    }
                }

                GetOldImagePath(delFilePath.FullName, ref delFilePath);
            }
            catch (Exception ex)
            {
                //string str = this.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.ToString();

                //Machine.mLogger.log(str, LogType.ERROR, true);
            }
        }

        public void DeleteOldImage(string strDir, string usedDiskPercentage)
        {
            try
            { 
                double dHddTotalSize = (m_hddInfo.TotalSize) / 1024 / 1024 / 1024;
                double dHddFreeSize = (m_hddInfo.AvailableFreeSpace) / 1024 / 1024 / 1024;
                m_dUsedDiskPercentage = (dHddTotalSize - dHddFreeSize) / dHddTotalSize * 100;

                if (m_dUsedDiskPercentage < (Convert.ToDouble(usedDiskPercentage)))
                    return;


                int delCount = 0;
                while (delCount < 10)
                {
                    DirectoryInfo delFilePath = null;

                    GetOldImagePath(strDir, ref delFilePath); // 제일 오래된 경로 찾기
                    if (delFilePath == null) return;

                    FileInfo[] delFileList = delFilePath.GetFiles();

                    foreach (FileInfo file in delFileList)
                        file.Delete();

                    Directory.Delete(delFilePath.FullName, false);

                    if(delFileList.Count() != 0)
                        delCount++;
                }
                int j = 9;
            }
            catch(Exception ex)
            {
                //string str = this.ToString() + ":" + Utility.GetCurrentMethod() + ", " + ex.ToString();

                //Machine.mLogger.log(str, LogType.ERROR, true);
            }
        }
    }
}
