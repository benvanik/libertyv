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
using System.IO;
using LibertyV.Utils;

namespace LibertyV.Rage.RPF
{
    public class FileStreamCreator : IStreamCreator
    {
        public readonly long Offset;
        public readonly int Size;
        public readonly Stream FileStream;

        public FileStreamCreator(Stream fileStream, long offset, int size)
        {
            this.FileStream = fileStream;
            this.Offset = offset;
            this.Size = size;
        }

        public virtual Stream GetStream()
        {
            return new PartialStream(this.FileStream, this.Offset, this.Size);
        }

        public virtual int GetSize()
        {
            return this.Size;
        }

        public void WriteRaw(Stream stream)
        {
            // Write the original data
            using (Stream input = new PartialStream(this.FileStream, this.Offset, this.Size))
            {
                input.CopyTo(stream);
            }
        }

        public void Dispose()
        {
            // We don't want to close the file because it is used file
            // If you don't want to point to the original file, use external file stream creator instead
        }
    }
}
