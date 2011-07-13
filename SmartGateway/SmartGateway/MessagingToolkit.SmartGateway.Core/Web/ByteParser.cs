//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================

using System;
using System.Collections;
using System.Text;

namespace MessagingToolkit.SmartGateway.Core.Web
{
    class ByteParser
    {
        byte[] _bytes;
        int _pos;

        public ByteParser(byte[] bytes)
        {
            _bytes = bytes;
            _pos = 0;
        }

        public int CurrentOffset { get { return _pos; } }

        public ByteString ReadLine()
        {
            ByteString line = null;

            for (int i = _pos; i < _bytes.Length; i++)
            {
                if (_bytes[i] == (byte)'\n')
                {
                    int len = i - _pos;
                    if (len > 0 && _bytes[i - 1] == (byte)'\r')
                    {
                        len--;
                    }

                    line = new ByteString(_bytes, _pos, len);
                    _pos = i + 1;
                    return line;
                }
            }

            if (_pos < _bytes.Length)
            {
                line = new ByteString(_bytes, _pos, _bytes.Length - _pos);
            }

            _pos = _bytes.Length;
            return line;
        }
    }
}
