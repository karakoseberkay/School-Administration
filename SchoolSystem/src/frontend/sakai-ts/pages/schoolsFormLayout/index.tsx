import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Demo } from '../../types/types';


const FormLayoutDemo = () => {
    const [dropdownItem, setDropdownItem] = useState(null);
    const [deparments, setDepartments] = useState<Demo.Department[]>([]);
    
    const dropdownItems = [
        { name: 'Option 1', code: 'Option 1' },
        { name: 'Option 2', code: 'Option 2' },
        { name: 'Option 3', code: 'Option 3' }


       
    ];
 const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: 'React POST Request Example' })
    };
    
   
    
   function postStudent(){


    fetch('http://localhost:5191/api/student', {
        method: 'POST',
        body: JSON.stringify({
          // Add parameters here
        }),

        headers: {
          'Content-type': 'application/json; charset=UTF-8',
        },
      })
         .then((response) => response.json())
         .then((d) => d as Demo.Student[])
         .catch((err) => {
            console.log(err.message);
         });



   }

    return (
        <div className="grid">
            <div className="col-12 md:col-6">
                
                <div className="card">
                    <h5>Department</h5>
                    <div className="formgroup-inline">
                        <div className="field">
                            <label htmlFor="firstname1" className="p-sr-only">
                                Firstname
                            </label>
                            <InputText id="firstname1" type="text" placeholder="Departman Adı" />
                        </div>
                       
                        <Button label="Ekle"></Button>
                    </div>
                </div>


                <div className="card">
                    <h5>Öğrenci</h5>
                    <div className="formgroup-inline">
                        <div className="field">
                            <label htmlFor="firstname1" className="p-sr-only">
                                Firstname
                            </label>
                            <InputText id="firstname1" type="text" placeholder="Öğrenci Adı" />
                        </div>
                        <div className="field">
                            <label htmlFor="lastname1" className="p-sr-only">
                                Lastname
                            </label>
                            <InputText id="lastname1" type="text" placeholder="Departman ID" />
                        </div>

                        <Button label="Ekle" onClick={postStudent}></Button>

                    </div>
                </div>

               

                <div className="card">
                    <h5>Öğretmen</h5>
                    <div className="formgroup-inline">
                        <div className="field">
                            <label htmlFor="firstname1" className="p-sr-only">
                                Firstname
                            </label>
                            <InputText id="firstname1" type="text" placeholder="Öğretmen Adı" />
                        </div>
                        <div className="field">
                            <label htmlFor="lastname1" className="p-sr-only">
                                Lastname
                            </label>
                            <InputText id="lastname1" type="text" placeholder="Departman ID" />
                        </div>
                        <Button label="Ekle"></Button>
                    </div>
                </div>

               
            </div>
        </div>
    );
};

export default FormLayoutDemo;


