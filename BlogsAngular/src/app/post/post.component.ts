import {Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {Post, PostsService} from '../shared/posts.service';
import * as moment from 'moment';
import {MatDialog} from '@angular/material/dialog';
import {ChangePostModalComponent} from '../change-post-modal/change-post-modal.component';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  @Input()
  Post: Post;

  constructor(
    private postsService: PostsService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.Post.createDate = moment(this.Post.createDate).calendar();
  }

  onDelete(): void {
    this.postsService.deletePost(this.Post);
  }

  changePost(): void {
    this.dialog.open(ChangePostModalComponent, {
      data: {
        post: this.Post
      }
    });
  }
}
