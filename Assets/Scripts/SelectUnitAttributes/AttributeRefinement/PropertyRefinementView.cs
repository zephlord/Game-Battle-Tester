using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]
public class PropertyRefinementView : MonoBehaviour {

	private ScrollRect _properties;
	private InputField _name;
	private GameObject _propertyInputFieldPrefab;

	public void setName(InputField nameField)
	{
		_name = nameField;
	}

	public Type makeProperty()
	{

		if(_properties.content.childCount == 0)
			return null;

		// Get the current application domain for the current thread.
        AppDomain currentDomain = AppDomain.CurrentDomain;

        // Create a dynamic assembly in the current application domain, 
        // and allow it to be executed and saved to disk.
        AssemblyName aName = new AssemblyName("TempAssembly");
        AssemblyBuilder ab = currentDomain.DefineDynamicAssembly(
            aName, AssemblyBuilderAccess.RunAndSave);

        // Define a dynamic module in "TempAssembly" assembly. For a single-
        // module assembly, the module has the same name as the assembly.
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

        // Define a public enumeration with the name  and an 
        // underlying type of Integer.
        EnumBuilder eb = mb.DefineEnum(_name.text, TypeAttributes.Public, typeof(int));

        // Define members
		int count = 0;
		foreach(Transform trans in _properties.content)
		{
			string propName = trans.gameObject.GetComponent<PropertyFieldView>().GetName;
			if(name == "")
				continue;
			eb.DefineLiteral(propName, count);
			count++;
		}

        // Create the type and save the assembly.
        Type finished = eb.CreateType();
        ab.Save(aName.Name + ".dll");
		return finished;
	}

	public void addPropertyValue()
	{
		Instantiate(_propertyInputFieldPrefab, _properties.content);
	}
}