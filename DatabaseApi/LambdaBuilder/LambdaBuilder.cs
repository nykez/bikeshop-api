﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
		/// <returns>An expression build off the query string</returns>
		public static Expression<Func<T, bool>> Builder(String queryString) {
			String[] selections = queryString.Replace("?", "").Split("&");
			var parameters = Expression.Parameter(typeof(T), typeof(T).Name);
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
					if(typeof(T).GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null || field.ToLower() == "paint") continue;
					// Store the operator
					op = expressionSplit[1];
					// Store the value and convert space back into actual space char
					value = expressionSplit[2].ToLower().Replace("%20", " ");
					// Create the expression property
					prop = Expression.Property(parameters, field);
					// If the value has an OR in it, make an expression with an OR of all of those values then and that expression with the general one.
					if(value.Contains("|") && op == "=") {
						Expression tempEx = Expression.Default(typeof(bool));
						String[] values = value.Split("|");
						foreach(String v in values) {
							int tempVal;
							int? nullTemp = null;
							if(int.TryParse(v, out tempVal)) {
								nullTemp = int.Parse(v);
								cons = Expression.Constant(nullTemp);
							}else
								cons = Expression.Constant(v);
							tempEx = Expression.Or(tempEx, Expression.Equal(prop, Expression.Convert(cons, prop.Type)));
						}
						expression = Expression.And(expression, tempEx);
					} else {

						// Create the expression Constant
						int tempVal;
						int? nullTemp = null;
						if(int.TryParse(value, out tempVal)) {
							nullTemp = int.Parse(value);
							cons = Expression.Constant(nullTemp);
						}else
							cons = Expression.Constant(value);

						switch(op) {
							case "=": { // If the operator is an equals
										// Add the expression to the original
									expression = Expression.And(expression, Expression.Equal(prop, Expression.Convert(cons, prop.Type)));
									break;
								}

							case "%3C": { //If the operator is lessthan
									int? consInt = Int32.Parse(value);
									cons = Expression.Constant(consInt);
									expression = Expression.And(expression, Expression.LessThanOrEqual(prop, Expression.Convert(cons, prop.Type)));
									break;
								}
							case "%3E": { //If the operator is greaterthan
									int? consInt = Int32.Parse(value);
									cons = Expression.Constant(consInt);
									expression = Expression.And(expression, Expression.GreaterThanOrEqual(prop, Expression.Convert(cons, prop.Type)));
									break;
								}
						}
					}
				}
			}
			// If the expression never changed to the boolean type, we want to return all bikes(query was not specified)
			if(expression.Type != typeof(void)) {
				Expression<Func<T, bool>> ex = Expression.Lambda<Func<T, bool>>(expression, parameters);
				Debug.WriteLine(ex);
				return ex;
			} else {// else(no query) return all bikes
				return null;
			}
		}

		/// <summary>
		/// Used in URIBuilder, selects the operation to be done based on the request.
		/// </summary>
		/// <param name="selections"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		private static Expression SelectOperation(String[] selections, ParameterExpression parameters) {
			Expression left = (Expression)Expression.Not((Expression)Expression.Default(typeof(bool)));
			for(int index = 0; index < selections.Length - 1; index += 2) {
				string selection = selections[index];
				try {
					string str = selections[index + 1].Replace("%20", " ");
					MemberExpression memberExpression = Expression.Property((Expression)parameters, selection);
					ConstantExpression constantExpression = Expression.Constant((object)str);
					left = (Expression)Expression.And(left, (Expression)Expression.Equal((Expression)memberExpression, (Expression)constantExpression));
				} catch(IndexOutOfRangeException) {
					return (Expression)Expression.Empty();
				}
			}
			return left;
		}

		/// <summary>
		/// Builds a lambda based on a normal URI.
		/// </summary>
		/// <param name="queryString">The part of the URI to be built from.</param>
		/// <param name="name">The name of the table being selected from</param>
		/// <param name="operationType">The type of the operation wishing to be completed.</param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> URIBuilder(
			String queryString,
			String name,
			String operationType = "select") {
			String[] selections = queryString.Split("/");
			ParameterExpression parameters = Expression.Parameter(typeof(T), name);
			Expression body = (Expression)Expression.Empty();
			if(selections.Length != 0 && selections[0] != "") {
				switch(operationType) {
					case "select":
						body = LambdaBuilder<T>.SelectOperation(selections, parameters);
						break;
					case "purchase":
						body = LambdaBuilder<T>.SelectOperation(selections, parameters);
						break;
				}
			}
			if(!(body.Type != typeof(void)))
				return (Expression<Func<T, bool>>)null;
			return Expression.Lambda<Func<T, bool>>(body, parameters);
		}
	}
}