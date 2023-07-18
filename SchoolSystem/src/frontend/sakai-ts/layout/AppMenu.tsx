/* eslint-disable @next/next/no-img-element */

import React, { useContext } from 'react';
import AppMenuitem from './AppMenuitem';
import { LayoutContext } from './context/layoutcontext';
import { MenuProvider } from './context/menucontext';
import Link from 'next/link';
import { AppMenuItem } from '../types/types';

const AppMenu = () => {
    const { layoutConfig } = useContext(LayoutContext);

    const model: AppMenuItem[] = [
        {
            label: 'Home',
            items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', to: '/' }]
        },
        
        
        
        {
            label: 'OKUL YÖNETİM SİSTEMİ (OYS)',
            items: [
                { label: 'Departman Listeleme Merkezi', icon: 'pi pi-fw pi-table', to: '/schools/departments' },
                { label: 'Öğrenci Listeleme Merkezi', icon: 'pi pi-fw pi-table', to: '/schoolStudents' },
                { label: 'Öğretmen Listeleme Merkezi', icon: 'pi pi-fw pi-table', to: '/schoolTeachers' },
                { label: 'Veri Ekleme Merkezi', icon: 'pi pi-fw pi-id-card', to: '/schoolsFormLayout' }
               
            ]
        },
        
    ];

    return (
        <MenuProvider>
            <ul className="layout-menu">
                {model.map((item, i) => {
                    return !item?.seperator ? <AppMenuitem item={item} root={true} index={i} key={item.label} /> : <li className="menu-separator"></li>;
                })}

                
            </ul>
        </MenuProvider>
    );
};

export default AppMenu;
