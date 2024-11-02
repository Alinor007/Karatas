import { Control, Controller } from 'react-hook-form';

interface IProps {
  control: Control<any, any>;
  label?: string;
  inputName: string;
  inputType?: string;
  error?: string;
}

const InputField = ({ control, label, inputName, inputType = 'text', error }: IProps) => {
  const renderTopRow = () => {
    if (error) {
      return <span className='text-red-600 font-semibold'>{error}</span>;
    }
    if (label) {
      return <label className='block text-xs font-medium text-gray-900'>{label}</label>;
    }
    return null;
  };

  const dynamicClassName = error 
    ? 'w-full p-2 text-xs bg-transparent border-b-4 border-red-500'
    : 'w-full p-2 text-xs bg-transparent border-b-4 border-gray-200';

  return (
    <div className='px-4 my-2 w-9/12'>
      {renderTopRow()}
      <Controller
        name={inputName}
        control={control}
        render={({ field }) => <input {...field} autoComplete='off' type={inputType} className={dynamicClassName} />}
      />
    </div>
  );
};

export default InputField;
