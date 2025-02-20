'use client'

export default function LoginPage() {
    

    return (
        <div className="h-screen flex items-center justify-center w-full">
            <div className="max-w-md w-full bg-white border border-gray-300 rounded-lg p-8">
                <p className="text-3xl font-bold text-center text-gray-900 mb-4">
                    Вход
                </p>
                <form className="space-y-4" action="#" method="POST">
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
                        required
                        className="w-full px-4 py-2 border border-gray-300 rounded-lg"
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
                        required 
                        className="w-full px-4 py-2 border border-gray-300 rounded-lg"
                    />
                </div>
                <div>
                    <button 
                        type="submit" 
                        className="w-full py-2 px-4 bg-gray-700 text-white font-medium rounded-md focus:bg-gray-500">
                        Войти
                    </button>
                </div>
                </form>
            </div>
        </div>
    );
}