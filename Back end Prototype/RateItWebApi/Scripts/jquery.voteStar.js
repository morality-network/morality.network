/*
 * 评分星星
 *
 * @Desc    
 * @Cat       plugins/jQuery voteStar
 * @Date      2015/5
 * @Author    jiangminjing  
 * 
 * @Example
    $('.event_star').voteStar({
      callback: function(starObj, starNum){
        alert(starNum)
      }
    })  
 * 
*/

(function($){

  $.fn.extend({

    voteStar: function(options){

        var star = this;

        // 默认配置
        var defaults = {
            moveStar: false,                            // 鼠标move时点亮星星
            starLength: 5,                              // 星星数量
            precise: false,                             // 精确显示星星
            starAnimate: true,                         // 点亮时缓慢动画
            callback: null                              // 点亮后，执行什么操作 带参数当前点击对象和分数
        }

        var o = $.extend(defaults, options || {});    


        // 开启滑动效果
        if(o.moveStar){
            star.on('mousemove', function(event) {
              setStarWidth(event, $(this));
            });
            star.on('mouseleave', function(event) {
              var that = $(this);
                  rateValObj = that.siblings('input[type=text]'),
                  aStar_width = that.width() / o.starLength;
              if(!that.data('isSave')){
                that.find('i').width(0);
              }else{
                that.find('i').width(that.data('isSave') * aStar_width);
              }
            });
        }

        star.on('click', function(event) {
          // 开启动画效果
          if(o.starAnimate){
              $.each(star, function(index, ele) {
                  $(ele).addClass('star_animate');
              });
          }
          setStarWidth(event, $(this), true);
        });

        function setStarWidth(event, starObj, saveStar){
            var lightStar_width = event.pageX - starObj.offset().left,
                aStar_width = starObj.width() / o.starLength,
                starNum = o.precise ? lightStar_width/aStar_width : Math.ceil(lightStar_width/aStar_width);

            starObj.find('i').width(aStar_width * starNum);   
            if(saveStar){
              starObj.data('isSave', starNum);
              if(o.callback && typeof o.callback === 'function'){
                  o.callback(starObj, starNum);
              }
            }    
        }
    }    
  })


})(jQuery);

