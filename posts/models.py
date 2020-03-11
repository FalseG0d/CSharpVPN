from __future__ import unicode_literals
from django.db import models
from django.core.urlresolvers import reverse

# Create your models here.
def upload_location(instance,filename):
    return "%s/%s" %(instance.id,filename)

class Post(models.Model):
    #slug=models.SlugField(unique=True)
    height_field=models.IntegerField(default=0)
    width_field=models.IntegerField(default=0)
    image=models.ImageField(null=True,blank=True,upload_to=upload_location,
    width_field="width_field",height_field="height_field")
    title=models.CharField(max_length=120)
    content=models.TextField()
    update=models.DateTimeField(auto_now=True,auto_now_add=False)
    timestamp=models.DateTimeField(auto_now=False,auto_now_add=True)

    def __unicode__(self):
        return self.title

    def __str__(self):
        return self.title

    def get_absolute_url(self):
        return reverse("posts:detail",kwargs={"id":self.id})
        #return "/posts/%s/"%(self.id) 

    class Meta:
        ordering=["-update","-timestamp"]