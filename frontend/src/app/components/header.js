'use client'

import { useRouter } from "next/navigation"

export default function Header() {
    const router = useRouter();

    return (
        <header className="bg-gray-700 text-white h-14">
            <div className="w-full h-full flex">
                <div className="flex h-full">
                    <a onClick={ () => router.push('/trips') } className="cursor-default hover:bg-gray-500 text-white px-4 h-full text-base flex items-center">
                        Мои поездки
                    </a>
                    <a onClick={ () => router.push('/history') } className="cursor-default hover:bg-gray-500 text-white px-4 h-full text-base flex items-center">
                        История поездок
                    </a>
                </div>
                
                <div className="flex h-full mr-0 ml-auto">
                    <button onClick={ () => router.push('/register') } className="cursor-default hover:bg-gray-500 text-whit px-4 h-full text-base">
                        Регистрация
                    </button>
                    <button onClick={ () => router.push('/login') } className="cursor-default hover:bg-gray-500 text-white px-4 h-full text-base">
                        Логин
                    </button>
                </div>
            </div>
        </header>
    );
}