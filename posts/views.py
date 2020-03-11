from django.contrib import messages
from django.shortcuts import render,get_object_or_404,redirect
from django.http import HttpResponse,HttpResponseRedirect
from django.core.paginator import Paginator,EmptyPage,PageNotAnInteger
from django.shortcuts import render
from .forms import PostForm
from .models import Post
# Create your views here.

def post_create(request):
    form=PostForm(request.POST or None,request.FILES or None)

    if form.is_valid():
        instance=form.save(commit=False)
        instance.save() 
        messages.success(request,"Successfully Created")
        return HttpResponseRedirect(instance.get_absolute_url())
    
    context={
        "title":"Create a Post",
        "form":form
    }
    return render(request,"post_form.html",context)

def post_detail(request,id=None):
    instance=get_object_or_404(Post,id=id)
    context={
        "title":instance.title,
        "instance":instance
    }
    return render(request,"post_detail.html",context)    

def post_list(request):
    queryset_list=Post.objects.all()#.order_by("-timestamp")
    paginator = Paginator(queryset_list, 10) # Show 10 contacts per page.
    pagereqvar='page'
    page = request.GET.get(pagereqvar)
    try:
        queryset=paginator.page(page)
    except PageNotAnInteger:
        queryset=paginator.page(1)
    except EmptyPage:
        queryset=paginator.page(paginator.num_pages)

    context={
        "title":"List",
        "pagereqvar":pagereqvar,
        "object_list":queryset
    }
    return render(request,"post_list.html",context)

def post_update(request,id=None):
    instance=get_object_or_404(Post,id=id)
    form=PostForm(request.POST or None,request.FILES or None,instance=instance)
    
    if form.is_valid():
        instance=form.save(commit=False)
        instance.save()
        messages.success(request,"Successfully Updated")
        return HttpResponseRedirect(instance.get_absolute_url())
    

    context={
        "title":instance.title,
        "instance":instance,
        "form":form
    }
    return render(request,"post_form.html",context)    

def post_delete(request,id=None):
    instance=get_object_or_404(Post,id=id)
    instance.delete()
    messages.success(request,"Successfully Deleted")
    return redirect("posts:list")