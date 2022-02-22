using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Collections
{
	public static class QueryBuilder
	{
		public enum CompareOperators
		{
			equal, notEqual, greaterThan, lessThan, greaterThanOrEqual, lessThanOrEqual
		}
	}
}
