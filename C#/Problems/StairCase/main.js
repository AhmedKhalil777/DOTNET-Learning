function studentReport(courses) {
    if(courses.length<= 0)
    return null;

    var total = 0;
    var highScore = 0;
    var course = '';
   for(var i =0; i< courses.length ; i++){
     total +=  courses[i].grade;
     if(courses[i].grade > highScore){
        highScore = courses[i].grade;
        course = courses[i].title;
     }
   }
   return {
       average : total/courses.length,
       heighestScore : course +','+ highScore
   }
   
 }