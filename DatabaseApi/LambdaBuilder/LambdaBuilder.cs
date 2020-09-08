using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace DatabaseApi {
	/// <summary>
	/// Builds a lambda function to allow CRUD operations to be implemented easily.
	/// </summary>
	/// <typeparam name="T">The type of the object currently being operated with.</typeparam>
	public static class LambdaBuilder<T> {
		/// <summary>
		/// Creates a lambda function based on the type and query passed in.
		/// </summary>
		/// <param name="queryString">Querystring from URL containing requested conditions.</param>
		/// <param name="name">The name wished to represent the returned expression.</param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> Builder(String queryString, String name) {
			String[] selections = queryString.Replace("?", "").Split("&");
			var parameters = Expression.Parameter(typeof(T), name);
			MemberExpression prop;
			ConstantExpression cons;
			Expression expression = Expression.Empty();
			if(selections.Length > 0 && selections[0] != "") {

				// A bit of hackery, the default bool expression is FALSE, so in order to create a bool expression, it must be notted
				expression = Expression.Not(Expression.Default(typeof(bool)));
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
