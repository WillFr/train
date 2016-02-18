using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median
{
    public class Solution
    {
        public static float GetMedian(int[] sortedArr1, int[] sortedArr2)
        {
            #region input validation and special cases
            if ((sortedArr1 == null && sortedArr2 == null)
                || (sortedArr1 == null && sortedArr2.Length == 0)
                || (sortedArr2 == null && sortedArr1.Length == 0)
                || (sortedArr1!= null && sortedArr2!=null && sortedArr1.Length == 0 && sortedArr2.Length == 0)
                )
            {
                throw new InvalidOperationException("Can't get the median from array with 0 length");
            }

            if (sortedArr1 == null || sortedArr1.Length == 0)
            {
                return GetMedian(sortedArr2);
            }

            if (sortedArr2 == null || sortedArr2.Length == 0)
            {
                return GetMedian(sortedArr1);
            }

            var n = sortedArr1.Length > sortedArr2.Length ? sortedArr1 : sortedArr2;
            var m = n == sortedArr1 ? sortedArr2 : sortedArr1;

            var mN = GetMedian(n);
            var mM = GetMedian(m);

            if (mN == mM)
            {
                return mN;
            }



            if (m.First() > n.Last() || m.Last() < n.First())
            {
                var t = GetMedianI(n)
                                      + (float) m.Length/2*
                                      (m.Last() > n.First()? 1: -1);
                if (t == -0.5)
                {
                    return m.Last() + (float)(n[0] - m.Last()) / 2;
                }
                if (t == n.Length-0.5)
                {
                    return n.Last() + (float)(m[0] - n.Last()) / 2;
                }
                if (sortedArr1.Length % 2 == sortedArr2.Length % 2)
                {
           
                    return n[(int)(t-0.5)] + (float)(n[(int)(t + 0.5)] - n[(int)(t - 0.5)]) / 2;
                }

                return n[(int)t];
            }

            #endregion


            var mni = GetMedianI(n);

            int under = 0,over = 0, eq;
            GetNbElementUnder(mN, m, out under, out over, out eq);
            var offset = Math.Abs((float) (over - under)/2)- (float)eq / 2;

            if (offset == 0)
            {
                if (mni%1 == 0 || (m.Length + n.Length)%2 == 1 || eq >= 2)
                {
                    return mN;
                }
                else
                {
                    var mlc = under < over? mN : (float)m[under - 1];
                    var mrc = under > over ? mN : (float)m[m.Length - over];

                    var l = (int) Math.Max(n[(int) Math.Floor(mni)], mlc);
                    var r = (int) Math.Min(n[(int) Math.Ceiling(mni)], mrc);
                    return Avg(l, r);
                }
            }else if (over<under)
            {
                return OffsetMedianLeft(n, m, offset, mni, under);
            }
            else
            {
                return OffsetMedianRight(n, m, offset, mni, over);
            }
        }

        private static float OffsetMedianLeft(int[] n, int[] m, float offset, float curMedIdx, int k)
        {
            var lp = n[(int) Math.Floor(curMedIdx)];
            var rp = n[(int)Math.Ceiling(curMedIdx)];
            var bi = curMedIdx%1 != 0;

            var ni = n.Length%2 == 0 ? (int) Math.Floor(curMedIdx) : (int)curMedIdx-1;
            var mi = k-1;
            if (n.Length%2 == 0)
            {
                offset ++;
            }

            if (offset%1 != 0)
            {
                if (curMedIdx%1 != 0)
                {
                    rp = lp;
                    bi = false;
                }
                else
                {
                    if (n[ni] > m[mi])
                    {
                        lp = n[ni--];
                    }
                    else
                    {
                        lp = m[mi--];
                    }
                    bi = true;
                }

                offset -= (float)0.5;
            }


            while (offset != 0)
            {
                var lpVal = 0;
                if (n[ni] > m[mi])
                {
                    lpVal = n[ni--];
                }
                else
                {
                    lpVal = m[mi--];
                }

                if (bi)
                {
                    rp = lp;
                    lp = lpVal;
                }
                else {
                    lp = lpVal;
                    rp = lp;
                }
                offset--;
            }

            return Avg(lp, rp);
        }

        private static float OffsetMedianRight(int[] n, int[] m, float offset, float curMedIdx, int k)
        {
            var lp = n[(int)Math.Floor(curMedIdx)];
            var rp = n[(int)Math.Ceiling(curMedIdx)];
            var bi = curMedIdx % 1 != 0;

            var ni = n.Length % 2 == 0 ? (int)Math.Ceiling(curMedIdx): (int)curMedIdx + 1;
            var mi = m.Length - k;
            if (n.Length % 2 == 0)
            {
                offset++;
            }
            if (offset % 1 != 0)
            {
                if (curMedIdx % 1 != 0)
                {
                    lp = rp;
                    bi = false;
                }
                else
                {
                    if (n[ni] < m[mi])
                    {
                        rp = n[ni++];
                        bi = true;
                    }
                    else
                    {
                        rp = m[mi++];
                        bi = true;
                    }
                }

                offset -= (float)0.5;
            }

            while (offset != 0)
            {
                var rpVal = 0;
                if (n[ni] < m[mi])
                {
                    rpVal = n[ni++];
                }
                else
                {
                    rpVal = m[mi++];
                }

                if (bi)
                {
                    lp = rp;
                    rp = rpVal;
                }
                else {
                    rp = rpVal;
                    lp = rp;
                }
                offset--;
            }

            return Avg(lp, rp);
        }

        private static float Avg(float f, float pp)
        {
            return f + (pp - f)/2;
        }

        private static void GetNbElementUnder(float mN, int[] m, out int under, out int over, out int eq)
        {
            eq = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == mN)
                {
                    under = i;

                    while (i<m.Length && m[i] == mN)
                    {
                        eq++;
                        i++;
                    }
                    
                    over = m.Length - i;
                    return;
                }
                else if (m[i] > mN)
                {
                    under = i;
                    over = m.Length - i;
                    return;
                }
            }

            under = m.Length;
            over = 0;
        }


        private static float GetMedian(int[] sortedArr1)
        {
            return sortedArr1.Length%2 == 0 ? sortedArr1[sortedArr1.Length/2-1] + (float)(sortedArr1[sortedArr1.Length/2] - sortedArr1[sortedArr1.Length/2-1])/2 : sortedArr1[sortedArr1.Length / 2];
        }

        private static float GetMedianI(int[] sortedArr1)
        {
            return (float) (sortedArr1.Length % 2 == 0 ? sortedArr1.Length / 2 - 0.5 : sortedArr1.Length / 2);
        }

        private static float GetValueAtIndex(float i, int[] arr)
        {
            return GetValueAtIndex((int) Math.Floor(i), (int) Math.Ceiling(i), arr);
        }

        private static float GetValueAtIndex(int l, int r, int[] arr)
        {
            return Avg(arr[l], arr[r]);
        }
    }
}
