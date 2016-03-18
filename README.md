## Freeboard Orchard CMS Module

Jim Heising and Bug Labs, Inc. 
created [Freeboard](https://github.com/Freeboard/freeboard). 
It is:

> A damn-sexy, open source real-time dashboard builder for IOT and other web mashups. A free open-source alternative to Geckoboard.

It is released under the MIT license. It is quite popular. Presently, it has 2913 stars.

This [Orchard CMS](http://www.orchardproject.net/) module gives 
you Freeboard as securable content items.  It is not popular.  Presently, it has 2 stars.  

You can find this module in the [Orchard Gallery](http://gallery.orchardproject.net/Packages/Orchard.Module.Freeboard). 

## How to Use This Module

### Create a Freeboard

To create one, goto the Orchard CMS Adminstration site.  Under 
the *New* menu, click on *Freeboard*.

![Create Freeboard Content Item](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-create.jpg)

### Secure a Freeboard

If you *Enable Content Item access control*, you may assign *view* 
and *edit* permissions to the `Anonymous` or `Authenticated` roles. 

![Edit and Grant Permissions](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-save.jpg)

### Build and Save a Freeboard

In the content manager, click on the `view` link 
to take you to your freeboard.

![View Link](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-view-link.jpg)

You should see this:

![blank freeboard](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-blank.jpg)

The freeboard's route is `~/Modules/Freeboard/{id}` 
where `id` is the content item's numeric id.  I modified the 
Freeboard menu to load and save from Orchard.

Add some widgets and save it:

![freeboard updated](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-modified.jpg)

The configuration is saved with the content item. 
You can see it back in the admin site:

![freeboard updated in admin site](http://transformalize.com/Media/Default/projects/freeboard/orchard-freeboard-saved.jpg)

If you like, you can tweak it 
with the [CodeMirror](http://codemirror.net/) editor. 
For example, update `allow_edit` to false to make read only.

### Credit

* [Microsoft](http://www.microsoft.com/), and the [developers](http://www.orchardproject.net/about) of Orchard CMS.
* [Jim Heising](https://github.com/jheising) and [Bug Labs, Inc.](http://buglabs.net/) for Freeboard.
* [Code Mirror](https://github.com/codemirror/CodeMirror/)
* [Json.NET](http://www.newtonsoft.com/json)