﻿/*
 
    LibertyV - Viewer/Editor for RAGE Package File version 7
    Copyright (C) 2013  koolk <koolkdev at gmail.com>
   
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
  
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
   
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibertyV.Rage.RPF.V7.Entries;
using System.IO;
using System.Diagnostics;
using LibertyV.Rage.RPF.V7;
using LibertyV.Rage.RPF;

namespace LibertyV.Operations
{
    static class RPFOperations
    {
        public static bool IsRPF(FileEntry entry)
        {
            return entry.GetExtension() == ".rpf";
        }
        
        public static void OpenRPF(FileEntry entry)
        {
            string tempPath = Path.GetTempFileName();
            Stream tempFile = new FileStream(tempPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 0x1000, FileOptions.DeleteOnClose);
            LibertyV window = new LibertyV(new RPF7File(entry.Data.GetStream(), entry.Name), tempPath);
            window.ShowDialog();
            if (tempFile.Length > 0)
            {
                // Replace data
                entry.Data.Dispose();
                entry.Data = new ExternalFileStreamCreator(tempFile);
                entry.ViewItem.Update();
            }
            else
            {
                tempFile.Close();
            }
        }
    }
}
