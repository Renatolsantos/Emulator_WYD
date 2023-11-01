﻿namespace Emulator_WYD.Helper
{
    public static class PSecurity
    {
        #region Keys
        public static byte[] keyTable =
        {
            0x84, 0x87, 0x37, 0xD7, 0xEA, 0x79, 0x91, 0x7D, 0x4B, 0x4B, 0x85, 0x7D, 0x87, 0x81, 0x91, 0x7C,
            0x0F, 0x73, 0x91, 0x91, 0x87, 0x7D, 0x0D, 0x7D, 0x86, 0x8F, 0x73, 0x0F, 0xE1, 0xDD, 0x85, 0x7D,
            0x05, 0x7D, 0x85, 0x83, 0x87, 0x9C, 0x85, 0x33, 0x0D, 0xE2, 0x87, 0x19, 0x0F, 0x79, 0x85, 0x86,
            0x37, 0x7D, 0xD7, 0xDD, 0xE9, 0x7D, 0xD7, 0x7D, 0x85, 0x79, 0x05, 0x7D, 0x0F, 0xE1, 0x87, 0x7E,
            0x23, 0x87, 0xF5, 0x79, 0x5F, 0xE3, 0x4B, 0x83, 0xA3, 0xA2, 0xAE, 0x0E, 0x14, 0x7D, 0xDE, 0x7E,
            0x85, 0x7A, 0x85, 0xAF, 0xCD, 0x7D, 0x87, 0xA5, 0x87, 0x7D, 0xE1, 0x7D, 0x88, 0x7D, 0x15, 0x91,
            0x23, 0x7D, 0x87, 0x7C, 0x0D, 0x7A, 0x85, 0x87, 0x17, 0x7C, 0x85, 0x7D, 0xAC, 0x80, 0xBB, 0x79,
            0x84, 0x9B, 0x5B, 0xA5, 0xD7, 0x8F, 0x05, 0x0F, 0x85, 0x7E, 0x85, 0x80, 0x85, 0x98, 0xF5, 0x9D,
            0xA3, 0x1A, 0x0D, 0x19, 0x87, 0x7C, 0x85, 0x7D, 0x84, 0x7D, 0x85, 0x7E, 0xE7, 0x97, 0x0D, 0x0F,
            0x85, 0x7B, 0xEA, 0x7D, 0xAD, 0x80, 0xAD, 0x7D, 0xB7, 0xAF, 0x0D, 0x7D, 0xE9, 0x3D, 0x85, 0x7D,
            0x87, 0xB7, 0x23, 0x7D, 0xE7, 0xB7, 0xA3, 0x0C, 0x87, 0x7E, 0x85, 0xA5, 0x7D, 0x76, 0x35, 0xB9,
            0x0D, 0x6F, 0x23, 0x7D, 0x87, 0x9B, 0x85, 0x0C, 0xE1, 0xA1, 0x0D, 0x7F, 0x87, 0x7D, 0x84, 0x7A,
            0x84, 0x7B, 0xE1, 0x86, 0xE8, 0x6F, 0xD1, 0x79, 0x85, 0x19, 0x53, 0x95, 0xC3, 0x47, 0x19, 0x7D,
            0xE7, 0x0C, 0x37, 0x7C, 0x23, 0x7D, 0x85, 0x7D, 0x4B, 0x79, 0x21, 0xA5, 0x87, 0x7D, 0x19, 0x7D,
            0x0D, 0x7D, 0x15, 0x91, 0x23, 0x7D, 0x87, 0x7C, 0x85, 0x7A, 0x85, 0xAF, 0xCD, 0x7D, 0x87, 0x7D,
            0xE9, 0x3D, 0x85, 0x7D, 0x15, 0x79, 0x85, 0x7D, 0xC1, 0x7B, 0xEA, 0x7D, 0xB7, 0x7D, 0x85, 0x7D,
            0x85, 0x7D, 0x0D, 0x7D, 0xE9, 0x73, 0x85, 0x79, 0x05, 0x7D, 0xD7, 0x7D, 0x85, 0xE1, 0xB9, 0xE1,
            0x0F, 0x65, 0x85, 0x86, 0x2D, 0x7D, 0xD7, 0xDD, 0xA3, 0x8E, 0xE6, 0x7D, 0xDE, 0x7E, 0xAE, 0x0E,
            0x0F, 0xE1, 0x89, 0x7E, 0x23, 0x7D, 0xF5, 0x79, 0x23, 0xE1, 0x4B, 0x83, 0x0C, 0x0F, 0x85, 0x7B,
            0x85, 0x7E, 0x8F, 0x80, 0x85, 0x98, 0xF5, 0x7A, 0x85, 0x1A, 0x0D, 0xE1, 0x0F, 0x7C, 0x89, 0x0C,
            0x85, 0x0B, 0x23, 0x69, 0x87, 0x7B, 0x23, 0x0C, 0x1F, 0xB7, 0x21, 0x7A, 0x88, 0x7E, 0x8F, 0xA5,
            0x7D, 0x80, 0xB7, 0xB9, 0x18, 0xBF, 0x4B, 0x19, 0x85, 0xA5, 0x91, 0x80, 0x87, 0x81, 0x87, 0x7C,
            0x0F, 0x73, 0x91, 0x91, 0x84, 0x87, 0x37, 0xD7, 0x86, 0x79, 0xE1, 0xDD, 0x85, 0x7A, 0x73, 0x9B,
            0x05, 0x7D, 0x0D, 0x83, 0x87, 0x9C, 0x85, 0x33, 0x87, 0x7D, 0x85, 0x0F, 0x87, 0x7D, 0x0D, 0x7D,
            0xF6, 0x7E, 0x87, 0x7D, 0x88, 0x19, 0x89, 0xF5, 0xD1, 0xDD, 0x85, 0x7D, 0x8B, 0xC3, 0xEA, 0x7A,
            0xD7, 0xB0, 0x0D, 0x7D, 0x87, 0xA5, 0x87, 0x7C, 0x73, 0x7E, 0x7D, 0x86, 0x87, 0x23, 0x85, 0x10,
            0xD7, 0xDF, 0xED, 0xA5, 0xE1, 0x7A, 0x85, 0x23, 0xEA, 0x7E, 0x85, 0x98, 0xAD, 0x79, 0x86, 0x7D,
            0x85, 0x7D, 0xD7, 0x7D, 0xE1, 0x7A, 0xF5, 0x7D, 0x85, 0xB0, 0x2B, 0x37, 0xE1, 0x7A, 0x87, 0x79,
            0x84, 0x7D, 0x73, 0x73, 0x87, 0x7D, 0x23, 0x7D, 0xE9, 0x7D, 0x85, 0x7E, 0x02, 0x7D, 0xDD, 0x2D,
            0x87, 0x79, 0xE7, 0x79, 0xAD, 0x7C, 0x23, 0xDA, 0x87, 0x0D, 0x0D, 0x7B, 0xE7, 0x79, 0x9B, 0x7D,
            0xD7, 0x8F, 0x05, 0x7D, 0x0D, 0x34, 0x8F, 0x7D, 0xAD, 0x87, 0xE9, 0x7C, 0x85, 0x80, 0x85, 0x79,
            0x8A, 0xC3, 0xE7, 0xA5, 0xE8, 0x6B, 0x0D, 0x74, 0x10, 0x73, 0x33, 0x17, 0x0D, 0x37, 0x21, 0x19
        };
        #endregion

        public static void Encrypt(ref byte[] pBuffer)
        {
            byte checksumEnc = 0;
            byte checksumDec = 0;
            byte keyResult = 0;
            byte hashKey = pBuffer[2];
            uint keyIncrement = (uint)(keyTable[hashKey * 2] & 0xFF);

            for (uint i = 4, loopIterator = 0; i < BitConverter.ToInt16(pBuffer, 0); i++, keyIncrement++)
            {
                checksumDec += pBuffer[i];
                keyResult = keyTable[(keyIncrement & 0x800000FF) * 2 + 1];
                loopIterator = i & 3;

                switch (loopIterator)
                {
                    case 0:
                    pBuffer[i] += (byte)(keyResult * 2);
                    break;

                    case 1:
                    pBuffer[i] -= (byte)(keyResult >> 3);
                    break;

                    case 2:
                    pBuffer[i] += (byte)(keyResult * 4);
                    break;

                    case 3:
                    pBuffer[i] -= (byte)(keyResult >> 5);
                    break;
                }

                checksumEnc += pBuffer[i];
            }

            pBuffer[3] = (byte)(checksumEnc - checksumDec);
        }

        public static int Decrypt(byte[] pBuffer)
        {
            try
            {
                int offset = GetInitialOffset(pBuffer);
                uint keyIncrement = keyTable[pBuffer[2 + offset] * 2], keyResult = 0;
                byte checksumEnc = 0, checksumDec = 0;

                for (int i = 4, thisIterator = 0; i < BitConverter.ToInt16(pBuffer, offset); i++, keyIncrement++)
                {
                    checksumEnc += pBuffer[i + offset];
                    keyResult = keyTable[(keyIncrement & 0x800000FF) * 2 + 1];
                    thisIterator = i & 3;

                    switch (thisIterator)
                    {
                        case 0:
                        pBuffer[i + offset] -= (byte)(keyResult << 1);
                        break;

                        case 1:
                        pBuffer[i + offset] += (byte)((int)keyResult >> 3);
                        break;

                        case 2:
                        pBuffer[i + offset] -= (byte)(keyResult << 2);
                        break;

                        case 3:
                        pBuffer[i + offset] += (byte)((int)keyResult >> 5);
                        break;
                    }

                    checksumDec += pBuffer[i + offset];
                }

                if (pBuffer[3 + offset] != (byte)(checksumEnc - checksumDec))
                {
                    offset = -1;
                }

                return offset;
            }
            catch
            {
                return -1;
            }
        }

        public static int GetInitialOffset(byte[] Buffer)
        {
            int iOffset = 0;

            byte[] pBuffer = Buffer;

            if (pBuffer == BitConverter.GetBytes(0x1F11F311) && pBuffer[4] == 0x74)
            {
                iOffset = 4;
            }

            return iOffset;
        }
    }
}
