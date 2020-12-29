import {Component, OnInit} from '@angular/core';
import {Post, PostsService} from '../shared/posts.service';
import {PostType, PostTypeService} from '../shared/posttypes.service';
import {MatDialogRef} from '@angular/material/dialog';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-post-modal',
  templateUrl: './create-post-modal.component.html',
  styleUrls: ['./create-post-modal.component.css']
})
export class CreatePostModalComponent implements OnInit {

  constructor(
    private postsService: PostsService,
    private postTypeService: PostTypeService,
    public dialogRef: MatDialogRef<CreatePostModalComponent>
  ) { }

  public postTypes: PostType[] = [];
  public selectedPostTypeId = 0;

  public post: Post = {
    createDate: new Date(),
    postContent: '',
    postType: null,
    user: {
      id: 1,
      login: 'John'
    }
  };

  inputControl = new FormControl('', [
    Validators.required,
    Validators.minLength(5),
  ]);

  ngOnInit(): void {
    this.postTypeService.fetchAllPostTypes();
    this.postTypeService.getPostsTypes().subscribe(types => {
      this.postTypes = types;
      this.post.postType = types[0];
    });
  }

  addPost(): void {
    if (!this.inputControl.valid) {
      return;
    }
    this.post.postType = this.postTypes.filter(pt => pt.id === this.selectedPostTypeId)[0];
    this.postsService.savePost(this.post);
    this.dialogRef.close(this);
  }
}
