import {Component, Inject, OnInit} from '@angular/core';
import {Post, PostsService} from '../shared/posts.service';
import {PostType, PostTypeService} from '../shared/posttypes.service';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-change-post-modal',
  templateUrl: './change-post-modal.component.html',
  styleUrls: ['./change-post-modal.component.css']
})
export class ChangePostModalComponent implements OnInit {

  constructor(
    private postsService: PostsService,
    private postTypeService: PostTypeService,
    public dialogRef: MatDialogRef<ChangePostModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { post: Post }
  ) { }

  public postTypes: PostType[] = [];
  public post: Post = null;
  public selectedPostTypeId = 0;

  inputControl = new FormControl('', [
    Validators.required,
    Validators.minLength(5),
  ]);

  ngOnInit(): void {
    this.post = this.data.post;
    this.selectedPostTypeId = this.data.post.postType.id;
    this.postTypeService.fetchAllPostTypes();
    this.postTypeService.getPostsTypes().subscribe(types => {
      this.postTypes = types;
    });
  }

  changePost(): void {
    if (!this.inputControl.valid) {
      return;
    }
    this.post.postType = this.postTypes.filter(pt => pt.id === this.selectedPostTypeId)[0];
    this.postsService.changePost(this.post);
    this.dialogRef.close(this);
  }
}
