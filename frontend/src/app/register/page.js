'use client'

import { useRouter } from "next/navigation";
import { register } from "../services/auth";
import { useState } from "react";

export default function RegisterPage() {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const router = useRouter();

    async function reg() {
        await register(name, email, password);
        router.push('/login');
    }

    return (
        <div className="h-screen flex items-center justify-center w-full">
            <div className="max-w-md w-full bg-white border border-gray-700 rounded-lg p-8">
                <p className="text-3xl font-bold text-center text-gray-900 mb-4">
                    Регистрация
                </p>
                <form className="space-y-4" action="#" method="POST" onSubmit={async (e) => {
                    e.preventDefault();
                    await reg();
                }}>
                <div className="flex items-center">
                    <label 
                        htmlFor="name" 
                        className="block text-sm font-medium text-gray-700 w-24"
                    >
                        Имя:
                    </label>
                    <input 
                        id="name" 
                        name="name" 
                        type="text" 
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required 
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    />
                </div>
                <div className="flex items-center">
                    <label 
                        htmlFor="email" 
                        className="block text-sm font-medium text-gray-700 w-24"
                    >
                        Email:
                    </label>
                    <input
                        id="email"
                        name="email"
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    />
                </div>
                <div className="flex items-center">
                    <label 
                        htmlFor="password" 
                        className="block text-sm font-medium text-gray-700 w-24"
                    >
                        Пароль:
                    </label>
                    <input 
                        id="password" 
                        name="password" 
                        type="password" 
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required 
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    />
                </div>
                <div>
                    <button 
                        type="submit" 
                        className="w-full py-2 px-4 bg-gray-700 text-white font-medium rounded-md focus:bg-gray-500">
                        Зарегистрироваться
                    </button>
                </div>
                </form>
            </div>
        </div>
    );
}