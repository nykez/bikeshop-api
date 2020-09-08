using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using static System.Linq.Expressions.LambdaExpression;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DatabaseApi {
	public static class LambdaBuilder<T> {
		public static Expression<Func<T, bool>> Builder(String queryString, Type type, String name) {
			String[] selections = queryString.Replace("?", "").Split("&");
			var parameters = Expression.Parameter(type, name);
			Debug.WriteLine(parameters.Type);
			MemberExpression prop;
			ConstantExpression cons;
			Expression expression = Expression.Empty();
			if(selections.Length > 0 && selections[0] != "") {

				// A bit of hackery, the default bool expression is FALSE, so in order to create a bool expression, it must be notted
				expression = Expression.Not(Expression.Default(typeof(bool)));
				// A list for all of the expressions to be stored in for later Anding with the original expression(maybe just and them instead of this?)
				List<Expression> expressionList = new List<Expression>();
				// The field to the expression being extracted
				String field;
				// The operator to the expression being extracted
				String op;
				// The value to the expression being extracted
				String value;
				// A string to store each part of the expression(only one split happens)
				String[] expressionSplit;
				foreach(String q in selections) {
					// We need to replace the instances of these chars to the string representation like is done with space
					expressionSplit = Regex.Split(q, "(=|%3C|%3E)");
					// Store the field
					field = expressionSplit[0].ToLower();
					// Store the operator
					op = expressionSplit[1];
					// Store the value and convert space back into actual space char
					value = expressionSplit[2].ToLower().Replace("%20", " ");
					// Create the expression property
					prop = Expression.Property(parameters, field);
					// Create the expression Constant
					cons = Expression.Constant(value);
					switch(op) {
						case "=": { // If the operator is an equals
									// Add the expression to the original
								expression = Expression.And(expression, Expression.Equal(prop, cons));
								break;
							}

						case "%3C": { //If the operator is lessthan
									  //Check for nullable columns
								int? consInt = Int32.Parse(value);
								cons = Expression.Constant(consInt);
								//Convernt Expressions to both be nullable
								expression = Expression.And(expression, Expression.LessThan(prop, Expression.Convert(cons, prop.Type)));
								break;
							}
					}
				}
			}
			// If the expression never changed to the boolean type, we want to return all bikes(query was not specified)
			if(expression.Type != typeof(void)) {
				Expression<Func<T, bool>> ex = Expression.Lambda<Func<T, bool>>(expression, parameters);
				return ex;
			} else {// else(no query) return all bikes
				return null;
			}
		}
	}
}
