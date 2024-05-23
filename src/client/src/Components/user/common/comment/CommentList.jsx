import React, { useEffect, useState } from "react";
import { getCommentsByProductSlug } from "../../../../Api/Controller";
import { useParams } from "react-router-dom";
import CommentDetail from "./CommentDetail";

const CommentList = ({ reload }) => {
  const [comments, setComments] = useState([]);
  const param = useParams();
  let { slug } = param;

  useEffect(() => {
    getCommentsByProductSlug(slug).then((data) => {
      if (data) {
        setComments(data);
      } else setComments([]);
    });
  }, [reload]);

  return (
    <>
      <div>
        <h1 className="title">Danh sách bình luận của người dùng</h1>
        <div>
          {comments && comments.length > 0
            ? comments.map((item, index) => (
                <div key={index}>
                  <CommentDetail
                    image={item.imageUrl}
                    name={item.username}
                    detail={item.detail}
                    rating={item.rating}
                    commentDate={item.commentDate}
                  />
                </div>
              ))
            : "Không có comment"}
        </div>
      </div>
    </>
  );
};

export default CommentList;
