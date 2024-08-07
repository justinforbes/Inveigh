﻿/*
 * BSD 3-Clause License
 *
 * Copyright (c) 2024, Kevin Robertson
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 * list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 * this list of conditions and the following disclaimer in the documentation
 * and/or other materials provided with the distribution.
 *
 * 3. Neither the name of the copyright holder nor the names of its
 * contributors may be used to endorse or promote products derived from
 * this software without specific prior written permission. 
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiddity.SMB2
{
    enum FileInformationClass : byte
    {
        FileDirectoryInformation = 0x01,
        FileFullDirectoryInformation = 0x02,
        FileIdFullDirectoryInformation = 0x26,
        FileBothDirectoryInformation = 0x03,
        FileIdBothDirectoryInformation = 0x25,
        FileNamesInformation = 0x0C
    }

    enum QueryDirectoryRequestFlags : byte
    {
        SMB2_RESTART_SCANS = 0x01,
        SMB2_RETURN_SINGLE_ENTRY = 0x02,
        SMB2_INDEX_SPECIFIED = 0x04,
        SMB2_REOPEN = 0x10
    }

    class SMB2QueryDirectoryRequest
    {
        // https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-smb2/10906442-294c-46d3-8515-c277efe1f752
        public ushort StructureSize { get; set; }
        public byte FileInformationClass { get; set; }
        public byte Flags { get; set; }
        public uint FileIndex { get; set; }
        public byte[] FileId { get; set; }
        public uint FileNameOffset { get; set; }
        public uint FileNameLength { get; set; }
        public uint OutputBufferLength { get; set; }
        public byte[] Buffer { get; set; }
    }
}
