using ePlatform.Common.Abstracts;
using ePlatform.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ePlatform.Common.Providers
{
    public class DefaultSequenceProvider : ISequenceGenerator
    {
        private readonly object _sequenceLock = new object();
        private const int DEFAULT_INITIAL_SEQUENCE_VALUE = 0;

        /// <summary>
        /// 아직 사용하지 않고, 단순하게 초기화만 되었을 때 값
        /// - 아직 사용하지 않은 시퀀스에 대해서, 현재 값을 구하는 경우에도 이 값을 리턴함
        /// </summary>
        private readonly int _initializedSequenceValue = DEFAULT_INITIAL_SEQUENCE_VALUE;
        private readonly Dictionary<string, int> _sequenceDictionary = null;

        public DefaultSequenceProvider(int initializedSequenceValue = DEFAULT_INITIAL_SEQUENCE_VALUE)
        {
            this._initializedSequenceValue = initializedSequenceValue;
            this._sequenceDictionary = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        }

        #region ISequenceGenerator Implementation

        /// <summary>
        /// 현재 존재하는 시퀀스 전체를 초기화 한다.
        /// </summary>
        public virtual void Reset()
        {
            lock (this._sequenceLock)
            {
                this._sequenceDictionary.Clear();
            }
        }

        /// <summary>
        /// 주어진 시퀀스 키 값에 해당하는 시퀀스를 초기화 한다.
        /// </summary>
        /// <param name="sequenceKey">초기화 대상 시퀀스 키</param>
        public virtual void Reset(string sequenceKey)
        {
            if (string.IsNullOrWhiteSpace(sequenceKey))
                throw new ArgumentNullException("sequenceKey");

            lock (this._sequenceLock)
            {
                if (this._sequenceDictionary.ContainsKey(sequenceKey))
                    this._sequenceDictionary.Remove(sequenceKey);
            }
        }

        /// <summary>
        /// 주어진 시퀀스 키 값에 해당하는 다음 시퀀스 값을 구한다
        ///  - 처음 생성인 경우, _initializedSequenceValue 값을 리턴
        /// </summary>
        /// <param name="sequenceKey">시퀀스 키</param>
        /// <returns></returns>
        public virtual int GetNext(string sequenceKey)
        {
            if (string.IsNullOrWhiteSpace(sequenceKey))
                throw new ArgumentNullException("sequenceKey");

            int toReturn = _initializedSequenceValue;

            lock (this._sequenceLock)
            {
                if (this._sequenceDictionary.ContainsKey(sequenceKey)) {
                    toReturn = GetCurrentInternal(sequenceKey) + 1;
                    this._sequenceDictionary[sequenceKey] = toReturn;
                }
                else
                    toReturn = GetCurrentInternal(sequenceKey);
            }

            return toReturn;
        }

        /// <summary>
        /// 주어진 시퀀스 키 값에 해당하는 현재 시퀀스 값을 구한다.
        /// - 아직 해당 값이 초기화 되지 않은 경우, _initializedSequenceValue 값을 리턴
        /// </summary>
        /// <param name="sequenceKey"></param>
        /// <returns></returns>
        public virtual int GetCurrent(string sequenceKey)
        {
            if (string.IsNullOrWhiteSpace(sequenceKey))
                throw new ArgumentNullException("sequenceKey");

            int toReturn = _initializedSequenceValue;

            lock (this._sequenceLock)
            {
                toReturn = GetCurrentInternal(sequenceKey);
            }

            return toReturn;
        }

        /// <summary>
        /// 주어진 Key 요소로 구성되는, 시퀀스 키 값에 해당하는 다음 시퀀스 값을 구한다
        /// </summary>
        /// <param name="keyElements">시퀀스 키 구성요소</param>
        /// <returns></returns>
        public int GetNext(params string[] keyElements)
        {
            if (keyElements == null || keyElements.Length == 0)
                throw new ArgumentNullException("keyElements");

            return this.GetNext(BuildKey(keyElements));
        }

        /// <summary>
        /// 주어진 Key 요소로 구성되는, 시퀀스 키 값에 해당하는 현재 시퀀스 값을 구한다.
        /// </summary>
        /// <param name="keyElements">시퀀스 키 구성요소</param>
        /// <returns></returns>
        public int GetCurrent(params string[] keyElements)
        {
            if (keyElements == null || keyElements.Length == 0)
                throw new ArgumentNullException("keyElements");

            return this.GetCurrent(BuildKey(keyElements));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 주어진 시퀀스 키 값에 해당하는 현재 시퀀스 값을 구한다.
        /// - 아직 해당 값이 초기화 되지 않은 경우, _initializedSequenceValue 값을 리턴
        /// </summary>
        /// <param name="sequenceKey"></param>
        /// <returns></returns>
        private int GetCurrentInternal(string sequenceKey)
        {
            int toReturn = _initializedSequenceValue;

            if (this._sequenceDictionary.ContainsKey(sequenceKey))
                toReturn = this._sequenceDictionary[sequenceKey];
            else
                this._sequenceDictionary.Add(sequenceKey, toReturn);

            return toReturn;
        }

        private string BuildKey(IEnumerable<string> keyElements)
        {
            if (keyElements == null || keyElements.Count() == 0)
                throw new ArgumentNullException("keyElements");

            string toReturn = keyElements.BuildKey();

            return toReturn;
        }

        #endregion
    }
}
