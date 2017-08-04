using System.Resources;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("UrbanAirSharp Mk2")]
[assembly: AssemblyDescription("C# .Net library to simplify server-side calls to the Urban Airship API Version 3")]
#if RELEASE
[assembly: AssemblyConfiguration("RELEASE")]
#elif DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("CUSTOM")]
#endif
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("UrbanAirSharp Mk2")]
[assembly: AssemblyCopyright("Copyright © 2014-2016 Jeff Gosling (jeffery.gosling@gmail.com), 2016 Glenn R. Martin")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e9fb3b1e-6532-4c30-8d26-b32fdc635ccd")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.1.2")]
[assembly: AssemblyFileVersion("1.2.1.2")]

[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("en-US")]

