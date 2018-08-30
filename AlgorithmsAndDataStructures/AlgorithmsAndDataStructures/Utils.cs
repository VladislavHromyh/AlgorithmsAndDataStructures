using System;
using System.Collections.Generic;
using System.Text;

internal class Utils {
	public static void DebugElements(object[] elements) {
		foreach(var element in elements) {
			Console.WriteLine(element);
		}
	}

	public static void DebugElements(int[] elements) {
		foreach (var element in elements) {
			Console.WriteLine(element);
		}
	}

	public static void DebugElements(string[] elements) {
		foreach (var element in elements) {
			Console.WriteLine(element);
		}
	}
}