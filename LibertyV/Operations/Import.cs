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
using System.Windows.Forms;
using LibertyV.Utils;
using System.IO;
using LibertyV.Rage.RPF.V7;
using LibertyV.Rage.RPF;

namespace LibertyV.Operations
{
    static class Import
    {
        public static void ImportFiles(DirectoryEntry entry)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                new ImportingWindow(entry, Path.GetDirectoryName(fileDialog.FileNames[0]), fileDialog.FileNames.Select(filename => Path.GetFileName(filename)).ToList()).ShowDialog();
            }
        }
        public static void ImportFolder(DirectoryEntry entry)
        {
            string folder = GUI.FolderSelection();
        }
    }
}
