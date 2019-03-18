using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
	public class StringCalc
	{
		int num = 0;
		int result = 0;
		public int Add(string v)
		{
			string[] numbers = v.Split(',');
			if (v.Length == 0)
			{
				num = 0;
			}
			else
			{
				for(int i = 0; i < numbers.Length; i++)
				{
					num += int.Parse(numbers[i]);
				}
			}
			return num;
		}

		public void Parse(string v)
		{
			bool parsable = int.TryParse(v, out result);
			if (parsable)
			{
				Add(v);
			}
		}
	}
}
