﻿using System.Diagnostics.CodeAnalysis;

namespace KutCode.Optionality;

public static class Optional
{
	#region Optional

	/// <summary>
	/// Create Optional instance from value 
	/// </summary>
	/// <param name="value">Object represents TValue type</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static Optional<TValue> From<TValue>(TValue? value) where TValue : class
		=> new (value);
	
	/// <summary>
	/// Create <see cref="Optional{TValue}"/> instance from async Task result
	/// </summary>
	/// <param name="task">Task returning TValue</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static async Task<Optional<TValue>> FromAsync<TValue>(Task<TValue?> task) where TValue : class
		=> new (await task);
	
	/// <summary>
	/// Returns <see cref="Optional{TValue}.None">Optional{TValue}.None</see> property - represents empty value
	/// </summary>
	public static Optional<TValue> None<TValue>() where TValue : class => Optional<TValue>.None;
	
	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallback">Value, which will be returned, if Optional instance value is null</param>
	/// <returns>Optional value, if it's null, fallback value</returns>
	public static TValue Fallback<TValue>(this Optional<TValue> value, [NotNull] TValue fallback) where TValue : class
		=> value.HasValue ? value! : fallback;

	#endregion



	#region OptionalValue

	/// <summary>
	/// Create Optional instance from value 
	/// </summary>
	/// <param name="value">Object represents TValue type</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static OptionalValue<TValue> From<TValue>(TValue? value) where TValue : struct
		=> new (value);

	/// <summary>
	/// Create <see cref="OptionalValue{TValue}"/> instance from async Task result
	/// </summary>
	/// <param name="task">Task returning TValue</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static async Task<OptionalValue<TValue>> FromAsync<TValue>(Task<TValue?> task) where TValue : struct
		=> new (await task);

	/// <summary>
	/// Returns <see cref="OptionalValue{TValue}.None">OptionalValue{TValue}.None</see> property - represents empty value
	/// </summary>
	public static OptionalValue<TValue> NoneValue<TValue>() where TValue : struct => OptionalValue<TValue>.None;

	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallback">Value, which will be returned, if Optional instance value is null</param>
	/// <returns>Optional value, if it's null, fallback value</returns>
	public static TValue Fallback<TValue>(this OptionalValue<TValue> value, TValue fallback) where TValue : struct
		=> value.HasValue ? value.Value : fallback;

	#endregion
}