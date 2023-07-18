import { Demo } from '../../types/types';

export const TeacherService = {

    getTeachers() {
        return fetch('http://localhost:5191/api/Teacher')
            .then((res) => res.json())
            .then((d) => d as Demo.Teacher[]);
    },

    deleteTeacher(id:any){
        return fetch('http://localhost:5191/api/teacher/'+id, {
            method: 'DELETE'
          })
             .catch((err) => {
                console.log(err.message);
             });
    },
    updateTeacher(teacher:Demo.Teacher){

        return fetch('http://localhost:5191/api/teacher/'+teacher.id, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(teacher)
          });

    },
    postTeacher(teacher:Demo.Teacher) {

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(teacher)
        };
       return fetch('http://localhost:5191/api/teacher', requestOptions)

    },
   
};
