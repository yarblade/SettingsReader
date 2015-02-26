SettingsReader
==============
Read settings from the app.config (or web.config) has become easier with SettingsReader.
You need only create class with your settings and add settings in config file, SettingsReader will do the rest for you.
For example, you have:
```C#
class SimpleSettings
{
  public int ItemsPerRequest { get; set; }
  public TimeSpan RequestInterval { get; set; }
}
```
Then you need to add this xml to app.config (or web.config):
```xml
<appSettings>
  <add key="SimpleSettings.ItemsPerRequest" value="100"/>
  <add key="SimpleSettings.RequestInterval" value="00:01:00"/>
</appSettings>
```
And now you can get your settings with `AppSettingsReader`
```C#
var settings = new AppSettingsReader().Read<SimpleSettings>();
```
Also you can change `prefix` of keys in `<appSettings>`. For example:
```xml
<appSettings>
  <add key="simple.ItemsPerRequest" value="100"/>
  <add key="simple.RequestInterval" value="00:01:00"/>
</appSettings>
```
Then you call Read method with new `prefix` (by default `prefix` matches your settings class type name)
```C#
var settings = new AppSettingsReader().Read<SimpleSettings>("simple");
```
If you want to use complex settings with lists, arrays and other classes, you need use `ConfigurationSectionReader`.
For example, you have:
```C#
class Certificate
{
  public string Name { get; set; }
  public string StoreLocation { get; set; }
  public string StoreName { get; set; }
}

class ComplexSettings
{
  public int ItemsPerRequest { get; set; }
  public TimeSpan RequestInterval { get; set; }
  public Certificate[] Certificates { get; set; }
}
```
You need add new configuration section to your app.config (or web.config)
```xml
<configSections>
  <section name="complexSettings" type="SettingsReader.Configuration.ConfigurationSection, SettingsReader"/>
</configSections>
```
and your settings
```xml
<complexSettings>
  <itemsPerRequest>100</itemsPerRequest>
  <requestInterval>00:01:00</requestInterval>
  <certificates>
    <name>SslRootCa</name>
    <storeName>My</storeName>
    <storeLocation>LocalMachine</storeLocation>
  </certificates>
  <certificates>
    <name>Ssl</name>
    <storeName>My</storeName>
    <storeLocation>LocalMachine</storeLocation>
  </certificates>
</complexSettings>
```
Now you can get settings by `ConfigurationSectionReader`
```C#
var settings = new ConfigurationSectionReader().Read<ComplexSettings>();
```
By default configuration section name matches settings class type name in camelCase, but you can use any other name. For example:
```C#
var settings = new ConfigurationSectionReader().Read<ComplexSettings>("complex");
```
